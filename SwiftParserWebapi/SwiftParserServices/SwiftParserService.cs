using SwiftparserData.Models;
using SwiftparserData.Repositories;
using SwiftParserServices.Exceptions;

namespace SwiftParserServices
{
    public class SwiftParserService : ISwiftParserService
    {
        private readonly ISwiftMessageRepository swiftMessageRepository;

        public SwiftParserService(ISwiftMessageRepository swiftMessageRepository)
        {
            this.swiftMessageRepository = swiftMessageRepository;
        }

        public Task ParseSwiftMessage(string messageText)
        {
            var swiftMessage = ParseTextToSwiftMessage(ref messageText);

            return this.swiftMessageRepository.InsertSwiftMessage(swiftMessage);
        }

        private static SwiftMessage ParseTextToSwiftMessage(ref string messageText)
        {
            // Remove any newline characters and trim the input text
            messageText = messageText.Replace(Environment.NewLine, "").Trim();
            var tagValues = GetMessageByTag(messageText);

            // Create a new SwiftMessage object from the tag values
            ValidateMessage(tagValues);

            var senderCode = tagValues["1"];
            var messageType = tagValues["2"];
            var textBlock = tagValues["4"].Trim();
            var authenticationCode = tagValues["5"];

            return new SwiftMessage(senderCode, messageType, textBlock, authenticationCode);
        }

        private static void ValidateMessage(Dictionary<string, string> tagValues)
        {
            if (!tagValues.ContainsKey("1"))
            {
                throw new SwiftInvalidMessageException("Sender code is missing");
            }
            else if (!tagValues.ContainsKey("2"))
            {
                throw new SwiftInvalidMessageException("Message Type is missing");
            }
            else if (!tagValues.ContainsKey("4"))
            {
                throw new SwiftInvalidMessageException("Text Block is missing");
            }
        }

        private static Dictionary<string, string> GetMessageByTag(string messageText)
        {
            // Split the input text by the opening bracket
            var messageParts = messageText.Split('{');

            // Create a dictionary to store the tag values
            var tagValues = new Dictionary<string, string>();
            var validTagNumbers = new HashSet<string>() { "1", "2", "4", "5" };
            var previousTagNumber = "";
            // Iterate over the message parts
            for (int i = 1; i < messageParts.Length; i++)
            {
                var part = messageParts[i].Trim();

                // Get the tag number
                var tagNumber = part.Substring(0, part.IndexOf(':'));

                if (!validTagNumbers.Contains(tagNumber))
                {
                    tagNumber = previousTagNumber;
                }

                // Check if the tag value already exists
                if (tagValues.ContainsKey(tagNumber))
                {
                    // Combine the tag value with the existing value
                    tagValues[tagNumber] += "{" + part;
                }
                else
                {
                    // Add the tag value to the dictionary
                    tagValues[tagNumber] = part
                        .Substring(part.IndexOf(':') + 1)
                        .Replace("}", "");
                }

                previousTagNumber = tagNumber;

            }

            return tagValues;
        }
    }
}

using FluentMigrator;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Speakr.DbMigrations
{
    [Migration(3)]
    public class _20161015_3_TestData : Migration
    {
        Object defaultTalk;
        Object testTalk;

        public _20161015_3_TestData()
        {
            defaultTalk = new
            {
                Questionnaire = DefaultTalk()
            };

            testTalk = new
            {
                TalkEasyAccessKey = "TestTalk",
                TalkName = "This Is Talk 101",
                Topic = "Development Fun",
                Description = "New ways of trying cool things",
                SpeakerName = "TestSpeakerName",
                TalkCreationTime = DateTime.UtcNow,
                TalkStartTime = DateTime.UtcNow.AddDays(7),
                QuestionnaireId = 1
            };
        }
        public override void Up()
        {
            Insert.IntoTable("Questionnaires").Row(defaultTalk);
            Insert.IntoTable("Talks").Row(testTalk);
        }

        public override void Down()
        {
            Delete.FromTable("Questionnaires").Row(defaultTalk);
            Delete.FromTable("Talks").Row(testTalk);
        }


        public static string DefaultTalk()
        {
            var questionList = new List<Object>
            {
                new
                {
                    QuestionId = "Question-1",
                    QuestionText = "How much did you enjoy the talk?",
                    Answer = "",
                    ResponseType = AnswerTypes.Emoji,
                    IsRequired = true
                },

                new
                {
                    QuestionId = "Question-2",
                    QuestionText = "How would you rate this talk?",
                    Answer = "",
                    ResponseType = AnswerTypes.Rating,
                    IsRequired = false
                },

                new
                {
                    QuestionId = "Question-3",
                    QuestionText = "Did you learn anything useful?",
                    Answer = "",
                    ResponseType = AnswerTypes.YesNo,
                    IsRequired = true
                },

                new
                {
                    QuestionId = "Question-4",
                    QuestionText = "Would you recommend this talk to a friend/colleague?",
                    Answer = "",
                    ResponseType = AnswerTypes.YesNo,
                    IsRequired = false
                },

                new
                {
                    QuestionId = "Question-5",
                    QuestionText = "Do you have any suggestions to improve this talk?",
                    Answer = "",
                    ResponseType = AnswerTypes.Text,
                    IsRequired = true
                },

                new
                {
                    QuestionId = "Question-6",
                    QuestionText = "Any other comments?",
                    Answer = "",
                    ResponseType = AnswerTypes.Text,
                    IsRequired = false
                }
            };

            return JsonConvert.SerializeObject(questionList);
        }
    }

    public enum AnswerTypes
    {
        Text,
        Emoji,
        Rating,
        YesNo
    };
}

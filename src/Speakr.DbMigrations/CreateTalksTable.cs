using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Speakr.DbMigrations
{
    [Migration(1)]
    public class CreateTalksTable : Migration
    {
        public override void Down()
        {
            Create.Table("Talk")
                .WithColumn("TalkID").AsString(32).NotNullable().PrimaryKey()
                .WithColumn("TalkName").AsString()
                .WithColumn("SpeakerID").AsGuid().NotNullable()
                .WithColumn("QuestionnaireID").AsGuid().NotNullable().ForeignKey()
                .WithColumn("TalkCreationTime").AsDateTime()
                .WithColumn("TalkStartTime").AsDateTime();

            Create.Table("Questionnaire")
                .WithColumn("QuestionnaireID").AsString().ReferencedBy("Talk", "QuestionnaireId")
                .WithColumn("Questions").AsString(Int32.MaxValue);

            Create.Table("Speaker")
                .WithColumn("SpeakerID").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("LastName").AsString();

            Create.Table("SpeakerEmail")
                .WithColumn("SpeakerID").AsGuid().NotNullable()
                .WithColumn("EmailAddress").AsString().NotNullable();

            Create.Table("QuestionnaireResponse")
                .WithColumn("TalkId").AsString(32)
                .WithColumn("FeedbackId").AsGuid();

            Create.Table("Feedback")
                .WithColumn("FeedbackId").AsGuid()
                .WithColumn("Answer").AsString(Int32.MaxValue);
        }

        public override void Up()
        {
            Delete.Table("Talk");
            Delete.Table("Questionnaire");
            Delete.Table("Speaker");
            Delete.Table("SpeakerEmail");
            Delete.Table("QuestionnaireResponse");
            Delete.Table("Feedback");
        }
    }
}

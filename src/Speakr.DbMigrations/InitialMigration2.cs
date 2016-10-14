using FluentMigrator;
using System;

namespace Speakr.DbMigrations
{
    [Migration(1)]
    public class InitialMigration2 : Migration
    {
        public override void Up()
        {
            Create.Table("Talks")
                .WithColumn("TalkID").AsString(32).NotNullable().PrimaryKey()
                .WithColumn("TalkName").AsString()
                .WithColumn("Topic").AsString()
                .WithColumn("Description").AsString()
                .WithColumn("SpeakerID").AsGuid().NotNullable()
                .WithColumn("QuestionnaireID").AsGuid().NotNullable().ForeignKey()
                .WithColumn("TalkCreationTime").AsDateTime()
                .WithColumn("TalkStartTime").AsDateTime();

            Create.Table("Questionnaires")
                .WithColumn("QuestionnaireID").AsString().ReferencedBy("Talk", "QuestionnaireId")
                .WithColumn("Questionnaire").AsString(Int32.MaxValue);

            Create.Table("Speakers")
                .WithColumn("SpeakerID").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("LastName").AsString();

            Create.Table("SpeakerEmails")
                .WithColumn("SpeakerID").AsGuid().NotNullable()
                .WithColumn("EmailAddress").AsString().NotNullable();

            Create.Table("QuestionnaireResponses")
                .WithColumn("TalkId").AsString(32)
                .WithColumn("FeedbackId").AsGuid();

            Create.Table("Feedbacks")
                .WithColumn("FeedbackId").AsGuid()
                .WithColumn("Answer").AsString(Int32.MaxValue);
        }

        public override void Down()
        {
            Delete.Table("Talks");
            Delete.Table("Questionnaires");
            Delete.Table("Speakers");
            Delete.Table("SpeakerEmails");
            Delete.Table("QuestionnaireResponses");
            Delete.Table("Feedbacks");
        }
    }
}

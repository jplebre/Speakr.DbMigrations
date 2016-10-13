using FluentMigrator;
using System;

namespace Speakr.DbMigrations
{
    [Migration(1)]
    public class InitialMigration1 : Migration
    {
        public override void Up()
        {
            Create.Table("Talks")
                .WithColumn("TalkID").AsString(32).NotNullable().PrimaryKey()
                .WithColumn("TalkName").AsString().NotNullable()
                .WithColumn("Topic").AsString()
                .WithColumn("Description").AsString()
                .WithColumn("SpeakerID").AsGuid().NotNullable()
                .WithColumn("QuestionnaireID").AsGuid().NotNullable().ForeignKey()
                .WithColumn("TalkCreationTime").AsDateTime()
                .WithColumn("TalkStartTime").AsDateTime();

            Create.Table("Questionnaires")
                .WithColumn("QuestionnaireID").AsString().ReferencedBy("Talk", "QuestionnaireID")
                .WithColumn("Questions").AsString(Int32.MaxValue);

            Create.Table("Feedbacks")
                .WithColumn("TalkID").AsString(32).NotNullable().ForeignKey()
                .WithColumn("Responses").AsString(Int32.MaxValue);

            Create.Table("Speakers")
                .WithColumn("SpeakerID").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("LastName").AsString().NotNullable();

            Create.Table("SpeakerEmails")
                .WithColumn("SpeakerID").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("EmailAddress").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Talks");
            Delete.Table("Questionnaires");
            Delete.Table("Feedbacks");
            Delete.Table("Speakers");
            Delete.Table("SpeakerEmails");
        }
    }
}

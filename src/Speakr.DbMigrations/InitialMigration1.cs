using FluentMigrator;
using System;

namespace Speakr.DbMigrations
{
    [Migration(1)]
    public class InitialMigration1 : Migration
    {
        public override void Up()
        {
            Create.Table("Talk")
                .WithColumn("TalkID").AsString(32).NotNullable().PrimaryKey()
                .WithColumn("TalkName").AsString()
                .WithColumn("Topic").AsString()
                .WithColumn("Description").AsString()
                .WithColumn("QuestionnaireID").AsGuid().NotNullable().ForeignKey()
                .WithColumn("TalkCreationTime").AsDateTime()
                .WithColumn("TalkStartTime").AsDateTime();

            Create.Table("Questionnaire")
                .WithColumn("QuestionnaireID").AsString().ReferencedBy("Talk", "QuestionnaireID")
                .WithColumn("Questions").AsString(Int32.MaxValue);

            Create.Table("Feedback")
                .WithColumn("TalkID").AsString(32).NotNullable().ForeignKey()
                .WithColumn("Responses").AsString(Int32.MaxValue);

            Create.Table("Speaker")
                .WithColumn("SpeakerID").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("LastName").AsString().NotNullable();

            Create.Table("SpeakerEmail")
                .WithColumn("SpeakerID").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("EmailAddress").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Talk");
            Delete.Table("Questionnaire");
            Delete.Table("Feedback");
            Delete.Table("Speaker");
            Delete.Table("SpeakerEmail");
        }
    }
}

using FluentMigrator;
using System;

namespace Speakr.DbMigrations
{
    [Migration(2)]
    public class _20161015_2_Questionnaires : Migration
    {
        public override void Up()
        {
            Create.Table("Questionnaires")
                .WithColumn("QuestionnaireID").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Questionnaire").AsString(Int32.MaxValue);

            Create.Table("Feedback")
                .WithColumn("FeedbackId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("TalkID").AsGuid().NotNullable()
                .WithColumn("Answer").AsString(Int32.MaxValue);

            Create.Column("QuestionnaireID").OnTable("Talks").AsInt64()
                .ForeignKey("Questionnaires", "QuestionnaireID");
        }

        public override void Down()
        {
            Delete.Column("QuestionnaireID").FromTable("Talks");

            Delete.Table("Questionnaires");
            Delete.Table("Feedback");
        }
    }
}

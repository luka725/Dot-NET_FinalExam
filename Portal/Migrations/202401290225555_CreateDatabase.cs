namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        EnrollmentId = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        IsLecturer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollmentId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        LessonId = c.Int(nullable: false, identity: true),
                        LessonName = c.String(),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LessonId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        GradeValue = c.String(),
                        LessonId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GradeId)
                .ForeignKey("dbo.Lessons", t => t.LessonId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.LessonId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PasswordHash = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        PersonalID = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);

            // Create stored procedure for GetLecturerSubjects
            Sql(@"CREATE PROCEDURE GetLecturerSubjects
                AS
                BEGIN
                    SELECT s.SubjectId, s.SubjectName, CONCAT(u.Name, ' ', u.LastName) AS LecturerFullName
                    FROM Subjects s
                    INNER JOIN Enrollments e ON s.SubjectId = e.SubjectId
                    INNER JOIN Users u ON e.UserId = u.UserId
                    WHERE e.IsLecturer = 1;
                END;"
            );
            // Create stored procedure for GetStudentsEnrolledInSubject
            Sql(@"CREATE PROCEDURE GetStudentsEnrolledInSubject
                @SubjectId INT
                AS
                BEGIN
                    SELECT Users.UserId, CONCAT(Users.Name, ' ', Users.LastName) AS FullName
                    FROM Enrollments
                    JOIN Users ON Enrollments.UserId = Users.UserId
                    WHERE Enrollments.SubjectId = @SubjectId AND Enrollments.IsLecturer = 0;
                END;"
            );

            Sql(@"CREATE PROCEDURE GetSubjectAverages
                AS
                BEGIN
                    SELECT
                        s.SubjectName,
                        AVG(CAST(g.GradeValue AS FLOAT)) AS AverageGrade
                    FROM
                        Subjects s
                    JOIN
                        Lessons l ON s.SubjectId = l.SubjectId
                    JOIN
                        Grades g ON l.LessonId = g.LessonId
                    GROUP BY
                        s.SubjectName;
                END;"
            );

            Sql(@"CREATE PROCEDURE GetSubjectUserGradeSummary
                AS
                BEGIN
                    SELECT
                        s.SubjectName,
                        u.Name + ' ' + u.LastName AS StudentName,
                        ISNULL(SUM(CAST(g.GradeValue AS INT)), 0) AS TotalGrades
                    FROM
                        Subjects s
                        INNER JOIN Enrollments e ON s.SubjectId = e.SubjectId
                        INNER JOIN Users u ON e.UserId = u.UserId
                        LEFT JOIN Lessons l ON s.SubjectId = l.SubjectId
                        LEFT JOIN Grades g ON l.LessonId = g.LessonId AND u.UserId = g.UserId
                    WHERE
                        e.IsLecturer = 0 -- To filter only students
                    GROUP BY
                        s.SubjectName,
                        u.Name,
                        u.LastName;
                END;"
            );
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Grades", "UserId", "dbo.Users");
            DropForeignKey("dbo.Enrollments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Grades", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.Enrollments", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Grades", new[] { "UserId" });
            DropIndex("dbo.Grades", new[] { "LessonId" });
            DropIndex("dbo.Lessons", new[] { "SubjectId" });
            DropIndex("dbo.Enrollments", new[] { "UserId" });
            DropIndex("dbo.Enrollments", new[] { "SubjectId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Grades");
            DropTable("dbo.Lessons");
            DropTable("dbo.Subjects");
            DropTable("dbo.Enrollments");
        }
    }
}

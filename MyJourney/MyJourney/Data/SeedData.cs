using MyJourney.Models;
using Microsoft.EntityFrameworkCore;

namespace MyJourney.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Matric.Any())
            {
                context.Matric.AddRange(
                    new Subject { SubjectName = "IsiZulu Home Language", SubjectMarks = 72, Level = 6 },
                    new Subject { SubjectName = "English First Additional Language", SubjectMarks = 57, Level = 4 },
                    new Subject { SubjectName = "Mathematics", SubjectMarks = 64, Level = 5 },
                    new Subject { SubjectName = "Life Orientation", SubjectMarks = 63, Level = 5 },
                    new Subject { SubjectName = "Agricultural Science", SubjectMarks = 71, Level = 6 },
                    new Subject { SubjectName="Life Sciences", SubjectMarks= 79, Level=6},
                    new Subject { SubjectName="Physical Sciences", SubjectMarks =82, Level = 7}
                );
            }

            if(!context.Modules.Any()) 
            {
                context.Modules.AddRange(
                    new Module { ModuleName= "Computer Literacy: Part 1",ModuleCode= "CSIL1511", ModuleMarks= 62, Credits = 4, Year=2020, PassDescription = "Pass"},
                    new Module { ModuleName = "Computer Literacy: Part 2",ModuleCode= "CSIL1521", ModuleMarks = 84, Credits = 4, Year = 2020, PassDescription = "Pass with Distinction"},
                    new Module { ModuleName = "Introduction to Computer Hardware",ModuleCode= "CSIS1553", ModuleMarks = 50, Credits = 16, Year = 2020, PassDescription = "Reassess exam: Pass"},
                    new Module { ModuleName = "Programming and Problem Solving: Part 1",ModuleCode="CSIS1614", ModuleMarks = 13, Credits = 16, Year = 2020, PassDescription = "Incomplete" },
                    new Module { ModuleName = "English Academic Literacy for Natural Sciences", ModuleCode= "EALN1508", ModuleMarks = 58, Credits = 32, Year = 2020, PassDescription = "Pass"},
                    new Module { ModuleName = "Introduction to Advanced Mathematics", ModuleCode= "MATM1622", ModuleMarks = 56, Credits = 8, Year = 2020, PassDescription = "Pass" },
                    new Module { ModuleName = "Mechanics, Waves and Optics", ModuleCode= "PHYS2614", ModuleMarks = 52, Credits = 16, Year = 2020, PassDescription = "Pass" },
                    new Module { ModuleName = "Electronics", ModuleCode= "PHYS2624", ModuleMarks = 61, Credits = 16, Year = 2020, PassDescription = "Pass" },
                    new Module { ModuleName = "Practical Work: Physics", ModuleCode= "PHYS2632", ModuleMarks = 60, Credits = 8, Year = 2020, PassDescription = "Pass" },
                    new Module { ModuleName = "Electromagnetism", ModuleCode= "PHYS2642", ModuleMarks = 47, Credits = 8, Year = 2020, PassDescription = "Fail" },
                    new Module { ModuleName = "Programming and Problem Solving: Part 1", ModuleCode= "CSIS1614", ModuleMarks = 59, Credits = 16, Year = 2021, PassDescription = "Pass" },
                    new Module { ModuleName = "Programming and Problem Solving: Part 2", ModuleCode= "CSIS1624", ModuleMarks = 75, Credits = 16, Year = 2021, PassDescription = "Pass with Distinction"},
                    new Module { ModuleName = "Introduction to the Internet and Web Page Development", ModuleCode= "CSIS1664", ModuleMarks = 83, Credits = 16, Year = 2021, PassDescription = "Pass with Distinction"},
                    new Module { ModuleName = "Scientific Computing", ModuleCode= "MATA2754", ModuleMarks = 33, Credits = 16, Year = 2021, PassDescription = "No admission to exam" },
                    new Module { ModuleName = "Calculus", ModuleCode= "MATM1534", ModuleMarks = 72, Credits = 16, Year = 2021, PassDescription = "Pass" },
                    new Module { ModuleName = "Calculus and Algebra", ModuleCode= "MATM1644", ModuleMarks = 66, Credits = 16, Year = 2021, PassDescription = "Pass" },
                    new Module { ModuleName = "Mechanics, Optics, Electricity and Biological and Medical Relevant Topics", ModuleCode= "PHYS1534", ModuleMarks = 70, Credits = 16, Year = 2021, PassDescription = "Pass" },
                    new Module { ModuleName = "Mechanics, Thermodynamics, Electricity and Magnetism", ModuleCode= "PHYS1624", ModuleMarks = 58, Credits = 16, Year = 2021, PassDescription = "Pass" },
					new Module { ModuleName = "Electromagnetism", ModuleCode = "PHYS2642", ModuleMarks = 75, Credits = 8, Year = 2021, PassDescription = "Pass with Distinction" },
					new Module { ModuleName = "Modern Physics", ModuleCode = "PHYS3714", ModuleMarks = 55, Credits = 16, Year = 2021, PassDescription = "Pass" },
					new Module { ModuleName = "Undergraduate Core Curriculum", ModuleCode = "UFSS1504", ModuleMarks = 62, Credits = 16, Year = 2021, PassDescription = "Pass" },
					new Module { ModuleName = "Data Structures and Advanced Programming", ModuleCode = "CSIS2614", ModuleMarks = 56, Credits = 16, Year = 2022, PassDescription = "Pass" },
					new Module { ModuleName = "Human-Computer Interaction", ModuleCode = "CSIS2624", ModuleMarks = 70, Credits = 16, Year = 2022, PassDescription = "Pass" },
					new Module { ModuleName = "Introduction to Databases and Database Management Systems: Part 1", ModuleCode = "CSIS2634", ModuleMarks = 67, Credits = 16, Year = 2022, PassDescription = "Pass" },
					new Module { ModuleName = "Software Design", ModuleCode = "CSIS2664", ModuleMarks = 75, Credits = 16, Year = 2022, PassDescription = "Pass with Distinction"},
					new Module { ModuleName = "Solid state physics", ModuleCode = "PHYS3724", ModuleMarks = 60, Credits = 16, Year = 2022, PassDescription = "Pass"},
					new Module { ModuleName = "Statistical Physics I", ModuleCode = "PHYS3732", ModuleMarks = 59, Credits = 8, Year = 2022, PassDescription = "Pass"},
					new Module { ModuleName = "Statistical Physics II", ModuleCode = "PHYS3742", ModuleMarks = 70, Credits = 8, Year = 2022, PassDescription = "Pass"},
					new Module { ModuleName = "Practical Work: Physics", ModuleCode = "PHYS3762", ModuleMarks = 66, Credits = 8, Year = 2022, PassDescription = "Pass"},
					new Module { ModuleName = "Practical Work: Physics", ModuleCode = "PHYS3752", ModuleMarks = 65, Credits = 8, Year = 2023, PassDescription = "Pass"},
					new Module { ModuleName = "Introduction to Databases and Database Management Systems: Part 2", ModuleCode = "CSIS3714", ModuleMarks = 78, Credits = 16, Year = 2023, PassDescription = "Pass with Distinction"},
					new Module { ModuleName = "Software Engineering", ModuleCode = "CSIS3724", ModuleMarks = 0, Credits = 16, Year = 2023, PassDescription = "Not Applicable"},
					new Module { ModuleName = "Internet Programming", ModuleCode = "CSIS3734", ModuleMarks = 68, Credits = 16, Year = 2023, PassDescription = "Pass"},
					new Module { ModuleName = "Computer Networks", ModuleCode = "CSIS3744", ModuleMarks = 0, Credits = 16, Year = 2023, PassDescription = "Not Applicable"},
					new Module { ModuleName = "Scientific Computing", ModuleCode = "MATA2754", ModuleMarks = 61, Credits = 16, Year = 2023, PassDescription = "Pass"},
					new Module { ModuleName = "Practical Work: Physics", ModuleCode = "PHYS3752", ModuleMarks = 65, Credits = 8, Year = 2023, PassDescription = "Pass"}

					);
            }
            if (!context.Skills.Any())
            {
                context.Skills.AddRange(
                    new Skill { Name= "Data Collection" },
                    new Skill { Name= "Design Patterns" },
                    new Skill { Name= "SOLID Principles" },
                    new Skill { Name= "Database Management (SQL)" },
                    new Skill { Name= "Problem Solving" },
                    new Skill { Name= "Object-Oriented Programming (OOP)" },
                    new Skill { Name= "ASP.NET Core MVC (C#, HTML, CSS & JavaScript)" },
                    new Skill { Name= "Scientific Computing (MATLAB & Python)" }
                    );
            }
            context.SaveChanges();
        }
    }
}

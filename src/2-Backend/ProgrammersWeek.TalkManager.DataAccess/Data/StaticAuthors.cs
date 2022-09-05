using ProgrammersWeek.TalkManager.Shared.Models;

namespace ProgrammersWeek.TalkManager.DataAccess.Data
{
    internal static class StaticAuthors
    {
        public static List<Author> GetList() =>
            new()
            {
                // DevOps
                new()
                {
                    Id = 1,
                    Name = "Brad",
                    Title = "Senior IT Consultant",
                    Bio = "Principal Consultant at Cognizant Softvision with more than 40 years of industry experience as an architect, full-stack developer, and seasoned DevOps practitioner.",
                    Picture = GetPicture(1)
                },
                new()
                {
                    Id = 2,
                    Name = "Gediminas",
                    Title = "Software Architect",
                    Bio = "Software Architect at Devbridge, helping teams deliver products. His experience and professional expertise cover a range of product development stages: from software architecture and its implementation to the adoption of agile development and more.",
                    Picture = GetPicture(3)
                },
                new()
                {
                    Id = 3,
                    Name = "Cosmin",
                    Title = "Software Engineer",
                    Bio = "DevOps Engineer with skills across PowerShell scripting, Jenkins pipelines, Chef recipes and cookbooks, Artifactory, Docker and AWS. Cosmin has previous experience in DevOps on analytics and CRM platforms, Oracle BI/DB, and as a former SharePoint/NET developer. He is passionate about IT technologies, new trends, chess, swimming and traveling around the world.",
                    Picture = GetPicture(3)
                },

                // .NET
                new()
                {
                    Id = 4,
                    Name = "Shaun",
                    Title = "CTO of Professional Services",
                    Bio = "Original creator of Oqtane and DotNetNuke, web application frameworks which have earned the recognition of being amongst the most pioneering and widely adopted Open Source projects native to the Microsoft platform. He has more than 30 years professional experience in architecting and implementing enterprise software solutions for private and public organizations. Based on his significant community contributions he has been recognized as a Microsoft Most Valuable Professional (MVP) for more than 14 years. He was recognized by Business In Vancouver in 2011 as a leading entrepreneur in their Forty Under 40 business awards, and is currently the Chair of the Project Committee for the .NET Foundation. Shaun is a Canadian living in Florida and is currently employed as the CTO of Professional Services for Cognizant.",
                    Picture = GetPicture(1)
                },
                new()
                {
                    Id = 5,
                    Name = "Stuart",
                    Title = "Principal Consultant",
                    Bio = "Software architect and technologist with focus on application modernization, cloud architecture, messaging, DevOps, .NET, C# and other Microsoft technologies. He is also a former Microsoft Regional Director and MVP on Connected Systems.",
                    Picture = GetPicture(1)
                },
                new()
                {
                    Id = 6,
                    Name = "Eric",
                    Title = "Principal Consultant",
                    Bio = "Cloud architect specialized on designing and building modern distributed applications.",
                    Picture = GetPicture(3)
                },
                new()
                {
                    Id = 7,
                    Name = "Javier",
                    Title = "Technical Director",
                    Bio = "Worked in the technology for more than 11 years as developer, lead, architect and director. Passionate about new technologies and technology updates, he is the father of one and also a bonsai teacher.",
                    Picture = GetPicture(1)
                },

                // Project Management
                new()
                {
                    Id = 8,
                    Name = "Norleshia",
                    Title = "Lead Project Manager",
                    Bio = "Accomplished Senior Project Manager with more than 20 years of IT and business management experience. She is recognized for on-time delivery of large-scale projects; leading multi-geographical endeavors while managing portfolios in excess of $10 million. Her certifications include PMP Certified (PMI), SAFe Certified - Program Consultant (SPC), Release Train Engineer (RTE), and Scrum Master (SSM).",
                    Picture = GetPicture(2)
                },
                new()
                {
                    Id = 9,
                    Name = "Kapil",
                    Title = "Chief Architect",
                    Bio = "CIO and Cofounder of Tin Roof. His experience founding two consulting companies and working at larger consulting firms over the last 22 years has given him a wide range of exposure to clients of varying size across many disparate industries, including pay TV, healthcare, real estate, hospitality, and payments.",
                    Picture = GetPicture(3)
                },

                // Mobile
                new()
                {
                    Id = 10,
                    Name = "Bill",
                    Title = "Senior Engineering Manager",
                    Bio = "Fly Delta Senior Engineering Manager and Architect. He also has specializations in iOS Mobile Development and Automation Tools Engineer. The Delta Engineering Team has been developing an internal custom automation system based on wiremock.org, and he has been developing the mock server system at Delta for two years.",
                    Picture = GetPicture(1)
                },
            };

        private static byte[] GetPicture(int number) =>
            File.ReadAllBytes($"./Avatars/dev-{number}.png");
    }
}

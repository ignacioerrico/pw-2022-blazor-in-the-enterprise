using ProgrammersWeek.TalkManager.Shared.Models;

namespace ProgrammersWeek.TalkManager.DataAccess.Data
{
    internal static class StaticTalks
    {
        public static List<Talk> GetList() =>
            new()
            {
                // DevOps
                new()
                {
                    Id = 1,
                    Title = "Cultural shift; DevOps is not",
                    Description = "The world often looks at DevOps as nothing more than a culture shift. Not a role and not a skill. Let's look at an alternative view.",
                    DateTimeUtc = new DateTime(2022, 9, 7, 13, 0, 0),
                    SessionType = SessionType.Online,
                    InterestAreaId = 1,
                    RegionId = 1,
                },
                new()
                {
                    Id = 2,
                    Title = "Continuous Delivery: Work Less, Do More",
                    Description = "This presentation will cover the main principles and best practices of Continuous Delivery. It will reveal how properly implemented Continuous Delivery programs can reduce distractions and repetitive work, and help to keep the focus on business problem solving and faster product delivery.",
                    DateTimeUtc = new DateTime(2022, 9, 7, 15, 0, 0),
                    SessionType = SessionType.Online,
                    InterestAreaId = 1,
                    RegionId = 3,
                },
                new()
                {
                    Id = 3,
                    Title = "Unikernels - Challenging Docker",
                    Description = "Unikernels technology: From basic to advanced. A brief history of its origins, an overview of the variations that appear over time, and the evolution of the technology using demonstrations.",
                    DateTimeUtc = new DateTime(2022, 9, 16, 14, 0, 0),
                    SessionType = SessionType.Online,
                    InterestAreaId = 1,
                    RegionId = 3,
                },

                // .NET
                new()
                {
                    Id = 4,
                    Title = "Building Blazor Hybrid Apps on .NET MAUI",
                    Description = ".NET MAUI is a cross-platform framework for creating native mobile and desktop apps with .NET. It unifies Android, iOS, macOS, and Windows APIs into a single API that allows a write-once run-anywhere developer experience, while additionally providing deep access to every aspect of each native platform.",
                    DateTimeUtc = new DateTime(2022, 9, 7, 17, 0, 0),
                    SessionType = SessionType.Online,
                    InterestAreaId = 2,
                    RegionId = 1,
                },
                new()
                {
                    Id = 5,
                    Title = "Using Feature Flags to Improve Development and Delivery",
                    Description = "Microsoft introduced built-in .NET platform level support for feature flags starting in .NET Core 3.0 in 2019. Feature flags, also known as feature toggles, are a powerful tool in modern application development, continuous integration, and DevOps, enabling many valuable scenarios such as separating deployment from release (\"dark launch\", etc.), targeting functionality to a select group of users, conducting A/B tests, shielding one team's work in progress from other teams, and others.",
                    DateTimeUtc = new DateTime(2022, 9, 8, 16, 0, 0),
                    SessionType = SessionType.Online,
                    InterestAreaId = 2,
                    RegionId = 1,
                },
                new()
                {
                    Id = 6,
                    Title = "Minimal API with MediatR and CQRS",
                    Description = "Minimal APIs enable quick service development with less boilerplate code if we combine it with popular libraries like MediatR and patterns like CQRS. Audience will learn how they can take advantage of it in their daily work and how this can help teams create microservices in a quicker, more scalable and testable way.",
                    DateTimeUtc = new DateTime(2022, 9, 12, 18, 0, 0),
                    SessionType = SessionType.Online,
                    InterestAreaId = 2,
                    RegionId = 2,
                },

                // Project Management
                new()
                {
                    Id = 7,
                    Title = "DiSC - Understanding Yourself and Others",
                    Description = "This talk will cover how to Understand team member personality styles and their impacts according to the DiSC behavioral assessment.",
                    DateTimeUtc = new DateTime(2022, 9, 6, 14, 0, 0),
                    SessionType = SessionType.Online,
                    InterestAreaId = 3,
                    RegionId = 1,
                },
                new()
                {
                    Id = 8,
                    Title = "Architecting for Success",
                    Description = "It's easy as an engineer to get caught up in new technology trends and attempt to apply them to a new project. While this can work for smaller projects, larger clients will have many existing processes, teams, and systems that you will need to interact with that could make your shiny new technology choices less than ideal when it comes to meeting client expectations.",
                    DateTimeUtc = new DateTime(2022, 9, 8, 14, 0, 0),
                    SessionType = SessionType.Online,
                    InterestAreaId = 3,
                    RegionId = 3,
                },

                // Mobile
                new()
                {
                    Id = 9,
                    Title = "Mock Driven Development for Front End Projects",
                    Description = "Arguably Mock Driven Development is a subset of Test Driven Development, where mock data is hosted on a proxy server to allow Engineers to easily mock API's under development. This included capturing state to vary endpoint responses to minimize backend server changes/deployments and instability.",
                    DateTimeUtc = new DateTime(2022, 9, 7, 17, 0, 0),
                    SessionType = SessionType.Online,
                    InterestAreaId = 4,
                    RegionId = 1,
                },
            };
    }
}

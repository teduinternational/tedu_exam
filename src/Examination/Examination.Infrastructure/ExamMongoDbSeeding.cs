using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Polly;
using Polly.Retry;
using Examination.Infrastructure.SeedWork;
using System.Collections.Generic;
using Examination.Domain.AggregateModels.CategoryAggregate;
using Examination.Domain.AggregateModels.QuestionAggregate;
using Examination.Domain.AggregateModels.ExamAggregate;
using Examination.Dtos.Enums;
using System.Linq;

namespace Examination.Infrastructure
{
    public class ExamMongoDbSeeding
    {
        public async Task SeedAsync(IMongoClient mongoClient, IOptions<ExamSettings> settings,
               ILogger<ExamMongoDbSeeding> logger)
        {
            var policy = CreatePolicy(logger, nameof(ExamMongoDbSeeding));
            await policy.ExecuteAsync(async () =>
            {
                var databaseName = settings.Value.DatabaseSettings.DatabaseName;
                var database = mongoClient.GetDatabase(databaseName);
                var categoryId1 = ObjectId.GenerateNewId().ToString();
                var categoryId2 = ObjectId.GenerateNewId().ToString();
                var categoryId3 = ObjectId.GenerateNewId().ToString();
                var categoryId4 = ObjectId.GenerateNewId().ToString();
                if (await database.GetCollection<Category>(Constants.Collections.Category).EstimatedDocumentCountAsync() == 0)
                {
                    await database.GetCollection<Category>(Constants.Collections.Category)
                        .InsertManyAsync(new List<Category>()
                        {
                            new Category(categoryId1,"Category 1","category-1"),
                            new Category(categoryId2,"Category 2","category-1"),
                            new Category(categoryId3,"Category 3","category-3"),
                            new Category(categoryId4,"Category 4","category-4"),
                        });
                }
                if (await database.GetCollection<Question>(Constants.Collections.Question).EstimatedDocumentCountAsync() ==
                    0)
                {
                    await database.GetCollection<Question>(Constants.Collections.Question)
                        .InsertManyAsync(GetPredefinedQuestions(categoryId1));
                }
                if (await database.GetCollection<Exam>(Constants.Collections.Exam).EstimatedDocumentCountAsync() ==
                    0)
                {
                    await database.GetCollection<Exam>(Constants.Collections.Exam)
                        .InsertManyAsync(GetPredefinedExams(categoryId1));
                }
            });
        }

        private List<Exam> GetPredefinedExams(string categoryId1)
        {
            return new List<Exam>()
            {
                new Exam("Exam 1", "Lorem Ipsum is simply dummy text of the printing and typesetting industry",
                    "<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>",
                    5,
                    TimeSpan.FromMinutes(10),
                    GetPredefinedQuestions(categoryId1).Take(5),
                    Level.Easy,
                    null,
                    4,
                    true),
                new Exam("Exam 2", "Lorem Ipsum is simply dummy text of the printing and typesetting industry",
                    "<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>",
                    5,
                    TimeSpan.FromMinutes(5),
                    GetPredefinedQuestions(categoryId1).Skip(5).Take(5),
                    Level.Medium,
                    null,
                    4,
                    true),
            };
        }
        private List<Question> GetPredefinedQuestions(string categoryId1)
        {
            return new List<Question>()
            {
                new("608cd754ef63d3914679ea5b","Question 1", QuestionType.SingleSelection, Level.Easy, categoryId1,
                    new List<Answer>()
                    {
                        new("608df4a7fe65c8efb4470544","Answer 1", true),
                        new("608df5376a9d681574657cc2","Answer 2"),
                        new("608df53aa5f60ba58550133f","Answer 3"),
                        new("608df53de99c4060eb629fe8","Answer 3")
                    },
                    "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..."),
                new("608cd754ef63d3914679ea60","Question 2", QuestionType.SingleSelection, Level.Easy, categoryId1,
                    new List<Answer>()
                    {
                        new("608df543c68c39b8f35a5045","Answer 1"),
                        new("608df54665f59b22462d175c","Answer 2", true),
                        new("608df54be0f049cbeaba337d","Answer 3"),
                        new("608df54e0fecd3136940353c","Answer 3")
                    },
                    "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..."),
                new("608cd754ef63d3914679ea65","Question 3", QuestionType.SingleSelection, Level.Easy, categoryId1,
                    new List<Answer>()
                    {
                        new("608df55272c30e7832703226","Answer 1", true),
                        new("608df556bd2b451e6b2f40db","Answer 2"),
                        new("608df5598fb7fddcaff2c2b8","Answer 3"),
                        new("608df55cb735565b0846e9d0","Answer 3")
                    },
                    "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..."),
                new("608cd754ef63d3914679ea6a","Question 4", QuestionType.SingleSelection, Level.Easy, categoryId1,
                    new List<Answer>()
                    {
                        new("608df560ac4ca31f8cd6af13","Answer 1"),
                        new("608df564e6d559052dd221db","Answer 2", true),
                        new("608df5681eee6ec535381ade","Answer 3"),
                        new("608df56bb74fea686a852a51","Answer 3")
                    },
                    "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..."),
                new("608cd754ef63d3914679ea6f","Question 5", QuestionType.SingleSelection, Level.Easy, categoryId1,
                    new List<Answer>()
                    {
                        new("608df570521ffdebd9aa0e57","Answer 1", true),
                        new("608df574690bbf32f92dc286","Answer 2"),
                        new("608df5779027cfe87b85fef7","Answer 3"),
                        new("608df57dd002589bd1d68ea9","Answer 3")
                    },
                    "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..."),
                new("608cd754ef63d3914679ea74","Question 6", QuestionType.SingleSelection, Level.Easy, categoryId1,
                    new List<Answer>()
                    {
                        new("608df585790fb419be6bb1d4","Answer 1"),
                        new("608df58b6c77aedda3ebc00f","Answer 2", true),
                        new("608df58e1d30025e41addcc4","Answer 3"),
                        new("608df5927bc56f38d4101385","Answer 3")
                    },
                    "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..."),
                new("608cd754ef63d3914679ea79","Question 7", QuestionType.SingleSelection, Level.Easy, categoryId1,
                    new List<Answer>()
                    {
                        new("608df59789452139c8f92c75","Answer 1"),
                        new("608df59ad8cb53e423462e36","Answer 2"),
                        new("608df59ce3a7c34d19a8a440","Answer 3", true),
                        new("608df59fee7260bd17889e28","Answer 3")
                    },
                    "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..."),
                new("608cd754ef63d3914679ea7e","Question 8", QuestionType.SingleSelection, Level.Easy, categoryId1,
                    new List<Answer>()
                    {
                        new("608df5a476d72c977b4fe1ac","Answer 1"),
                        new("608df5a875887b4fecd2445b","Answer 2"),
                        new("608df5ab6acaaa22696b6b24","Answer 3"),
                        new("608df5af6a192b13f317f9ee","Answer 3", true)
                    },
                    "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..."),
                new("608cd754ef63d3914679ea83","Question 9", QuestionType.SingleSelection, Level.Easy, categoryId1,
                    new List<Answer>()
                    {
                        new("608df5b3cf787a7520d0965e","Answer 1"),
                        new("608df5b73e6d19ad3a033670","Answer 2"),
                        new("608df5bb471294f71dd4818c","Answer 3", true),
                        new("608df5bec65ffde211cd31c5","Answer 3")
                    },
                    "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..."),
                new("608cd754ef63d3914679ea88","Question 10", QuestionType.SingleSelection, Level.Easy, categoryId1,
                    new List<Answer>()
                    {
                        new("608df5c1ec2dee54bc500cf3","Answer 1", true),
                        new("608df5c419a81be17ade4f5d","Answer 2"),
                        new("608df5c860d965e5e25584c5","Answer 3"),
                        new("608df5cc5fc1779a5da58532","Answer 3")
                    },
                    "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..."),
            };
        }
        private AsyncRetryPolicy CreatePolicy(ILogger<ExamMongoDbSeeding> logger, string prefix, int retries = 3)
        {
            return Policy.Handle<MongoException>().
                WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        logger.LogWarning(exception, "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}", prefix, exception.GetType().Name, exception.Message, retry, retries);
                    }
                );
        }

    }
}
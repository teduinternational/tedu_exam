﻿using Examination.Shared.Enums;
using Examination.Shared.Exams;
using Examination.Shared.Questions;
using Examination.Shared.SeedWork;
using Examination.Shared.SeedWork.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Examination.Application.Commands.V1.Exams.UpdateExam
{
    public class UpdateExamCommand : IRequest<ApiResult<bool>>
    {
        [Required]
        [ValidateMongoId]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ShortDesc { get; set; }

        public string Content { get; set; }

        [Required]
        public int NumberOfQuestions { get; set; }

        public TimeSpan? Duration { get; set; }

        public List<QuestionDto> Questions { get; set; }

        [Required]
        public Level Level { get; set; }

        [Required]
        public int NumberOfQuestionCorrectForPass { get; set; }

        [Required]
        public bool IsTimeRestricted { get; set; }

        public bool AutoGenerateQuestion { set; get; }

        [Required]
        public string CategoryId { get; set; }
    }
}

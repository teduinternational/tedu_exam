var TakeExamPage = function () {
    this.init = function () {
        initTimer();
        var index = $('#hidCurrentQuestionIndex').val();
        loadQuestion(index);
        registerEvents();
    }

    function registerEvents() {
        $('body').on('click', '#btnNextQuestion', function () {
            var resultId = $('#hidExamResultId').val();
            var questionId = $('#hidCurrentQuestionId').val();
            var currentQuestionIndex = parseInt($('#hidCurrentQuestionIndex').val());
            var lastQuestionIndex = parseInt($('#hidLastQuestionIndex').val());
            var answerIds = [];
            $('.answer-item:checked').each(function () {
                var id = $(this).prop('id');
                answerIds.push(id);
            });

            $.ajax({
                url: '/take-exam.html?handler=NextQuestion',
                data: JSON.stringify({
                    examResultId: resultId,
                    questionId: questionId,
                    answerIds: answerIds
                }),
                dataType: 'json',
                type: 'POST',
                contentType: 'application/json',
                success: function (res) {
                    if (currentQuestionIndex == lastQuestionIndex) {
                        $('#btnFinishExam').show();
                        return;
                    }
                    var nextQuestionIndex = currentQuestionIndex + 1;
                    $('#hidCurrentQuestionIndex').val(nextQuestionIndex);
                    loadQuestion(nextQuestionIndex);

                },
                error: function (jqXhr, textStatus, errorThrown) {
                    console.log(errorThrown);
                }
            });
        });

        $('body').on('click', '#btnSkipExam', function () {
            var resultId = $('#hidExamResultId').val();
            $.ajax({
                url: '/take-exam.html?handler=SkipExam',
                type: 'POST',
                data: JSON.stringify({
                    examResultId: resultId
                }),
                contentType: 'application/json',
            }).done(function (res) {
                console.log(res);
            });
        });

        $('body').on('click', '#btnFinishExam', function () {
            var resultId = $('#hidExamResultId').val();
            $.ajax({
                url: '/take-exam.html?handler=FinishExam',
                type: 'POST',
                data: JSON.stringify({
                    examResultId: resultId
                }),
                contentType: 'application/json'
            }).done(function (res) {
                window.location.href = "/exam-result.html?examResultId=" + resultId;
            });
        });

        $('body').on('click', '.navigate-question', function () {
            var index = $(this).data('index');
            $('#hidCurrentQuestionIndex').val(index);
            $('.navigate-question').removeClass("active-question");
            $(this).addClass('active-question');
            loadQuestion(index)
        });
    }

    function initTimer() {
        var remainingTime = $('#hidRemainingTime').val();
        var isTimeRestricted = $("#hidIsTimeRestricted").val();
        if (isTimeRestricted === "1") {
            var interval = setInterval(function () {
                var timer = remainingTime.split(':');
                //by parsing integer, I avoid all extra string processing
                var minutes = parseInt(timer[0], 10);
                var seconds = parseInt(timer[1], 10);
                --seconds;
                minutes = (seconds < 0) ? --minutes : minutes;
                if (minutes < 0) clearInterval(interval);
                seconds = (seconds < 0) ? 59 : seconds;
                seconds = (seconds < 10) ? '0' + seconds : seconds;
                //minutes = (minutes < 10) ?  minutes : minutes;
                $('#countdown').html(minutes + ':' + seconds);
                remainingTime = minutes + ':' + seconds;
            }, 1000);
        }
    }

    function loadQuestion(index) {
        var examResultId = $('#hidExamResultId').val();
        $.get("/take-exam.html?handler=Question&examResultId=" + examResultId + "&questionIndex=" + index)
            .done((res) => {
                console.log(res);
                $('#lblQuestionContent').text(res.content);
                $('#hidCurrentQuestionId').val(res.id);
                $('#lblCurrentQuestion').text((parseInt(index) + 1).toString());
                var html = '';
                if (res.questionType == 2) {
                    $('#lblNote').html(`<strong class="font-weight-semi-bold text-black">Note:</strong> There can be multiple correct answers to this question.`);
                    $('#lblNote').show();
                }
                else {
                    $('#lblNote').hide();
                }
                $.each(res.answers, function (index, item) {
                    if (res.questionType === 0) {
                        html += `<div>
                                        <label for="`+ item.id + `">
                                            <input type="radio" `+ (item.userChosen == true ? 'checked' : '') + ` class="answer-item" name="` + res.id + `" id="` + item.id + `" required>
                                            `+ item.content + `
                                        </label>
                                    </div>`;
                    } else {
                        html += `<div class="custom-control custom-checkbox mb-1">
                                        <input type="checkbox" `+ (item.userChosen == true ? 'checked' : '') + ` class="custom-control-input answer-item" id="` + item.id + `" required>
                                        <label class="custom-control-label custom--control-label" for="`+ item.id + `">
                                            `+ item.content + `
                                        </label>
                                    </div>`;
                    }

                });
                $('#divAnswers').html(html);
            });
    }
}
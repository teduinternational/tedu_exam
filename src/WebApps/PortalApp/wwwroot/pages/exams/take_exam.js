var TakeExamPage = function () {
    this.init = function () {
        initializeTimer();
    }

    function initializeTimer() {
        var remainingTime = $('#hidRemainingTime').val();
        var isTimeRestricted = $("hidIsTimeRestricted").val();
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
}

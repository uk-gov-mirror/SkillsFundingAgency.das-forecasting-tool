﻿var sfa = sfa || {};
sfa.AddApprenticeship = sfa.AddApprenticeship || {};

(function () {

    var init = function () {

        var formModel = GetAddApprenticeshipForm();
        showFundingCapMessage(formModel.TotalFundingCap !== undefined && formModel.TotalFundingCap !== "0")

        if ($("#choose-apprenticeship")) {
            $("#choose-apprenticeship").select2();
        }

        // open dropdownon on focus
        $(document).on('focus', '.select2', function () {
            $(this).siblings('select').select2('open');
        });

        // retain tabbed order after selection
        $('#choose-apprenticeship').on('select2:select', function () {
            $("#no-of-app").focus();
        });

        // retain tabbed order on close without selection
        $('#choose-apprenticeship').on('select2:close', function () {
            $("#no-of-app").focus();
        });

        $("#choose-apprenticeship").change(function () {
            calculateTotalCost();

            if (sfa.AddApprenticeship.Result)
                $('#apprenticeship-length').val(sfa.AddApprenticeship.Result.NumberOfMonths || 0);
        });

        $("#no-of-app").change(function () {
            if (sfa.AddApprenticeship.Result)
                calculateTotalCostLocal();
            else
                calculateTotalCost();
        });

        $("#startDateMonth, #startDateYear").change(function () {
            calculateTotalCostLocal();
        });

        $("#total-funding-cost").keyup(function () {
            var num = $('#total-funding-cost').val();
            var commaNum = AddEditApprentiecships.numberWithCommas(num);
            $('#total-funding-cost').val(commaNum);
        });

    };

    if (document.getElementById("estimate-add-apprenticeship")) {
        init();
    }

    function resetNumberOfMonths() {
        var courseId = $('#choose-apprenticeship').val();
        var previousCourseId = $('#PreviousCourseId').val();
        if (courseId !== previousCourseId) {
            var requestObject = {
                courseId: courseId
            };
        }
    }

    function calculateTotalCostLocal() {
        var formModel = GetAddApprenticeshipForm();

        var updated = refreshCalculation(formModel, sfa.AddApprenticeship.Result);
        showFundingCapMessage(updated);

    }

    function calculateTotalCost() {

        var model = GetAddApprenticeshipForm();
        
        $.ajax({
            type: "POST",
            url: 'course',
            data: JSON.stringify(model),
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                sfa.AddApprenticeship.Result = result;
                var update = refreshCalculation(model, result);
                showFundingCapMessage(update);

                if (model.NumberOfMonths === 0)
                    $('#apprenticeship-length').val(result.NumberOfMonths || 0);
            }
        });

        showFundingCapMessage(model.CourseId !== "" && model.NumberOfApprentices > 0);

    }

    function refreshCalculation(formModel, course) {
        var calc = AddEditApprentiecships.calculateFundingCap(formModel.StartDate, course)

        var fc = calc ? calc.FundingCap : 0;
        formModel.FundingCap = fc;
        formModel.TotalFundingCap = fc * formModel.NumberOfApprentices;

        updateView(formModel);

        return formModel.FundingCap > 0 && formModel.TotalFundingCap > 0;
    }

    function GetAddApprenticeshipForm() {
        return {
            CourseId: $('#choose-apprenticeship').val(),
            NumberOfApprentices: parseInt($('#no-of-app').val()),
            LevyValue: parseFloat($('#total-funding-cost').val()),
            StartDate: new Date($('#startDateYear').val(), $('#startDateMonth').val() - 1, 1),
            NumberOfMonths: parseInt($('#apprenticeship-length').val() || 0),
            FundingBands: $('#FundingPeriodsJson').val() ? JSON.parse($('#FundingPeriodsJson').val()) : '',
            TotalFundingCost: $('#total-funding-cost').val(),
            TotalFundingCap: $('#CalculatedTotalCap').val()
        }
    }

    function updateView(result) {
        var fc = AddEditApprentiecships.toGBP(result.FundingCap)
        var tfc = AddEditApprentiecships.toGBP(result.TotalFundingCap || 0)

        $('#funding-cap-details').html(fc);
        $('#apprentice-count-details').html(result.NumberOfApprentices);
        $('#total-cap-details').html(tfc);
        $('#total-funding-cost').val(tfc.replace('£', ''));
    }

    function showFundingCapMessage(show) {
        if (show) {
            $('#details-about-funding').hide();
            $('#details-about-funding-calculated').show();
        } else {
            $('#details-about-funding').show();
            $('#details-about-funding-calculated').hide();
        }
    }

}());
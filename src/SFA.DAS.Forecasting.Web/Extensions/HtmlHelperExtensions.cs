﻿using System;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace SFA.DAS.Forecasting.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString AddErrorClass<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            var expressionText = ExpressionHelper.GetExpressionText(expression);
            var fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expressionText);
            var state = htmlHelper.ViewData.ModelState[fullHtmlFieldName];

            if (state?.Errors == null || state.Errors.Count == 0)
            {
                return MvcHtmlString.Empty;
            }

            return new MvcHtmlString("error");
        }

        public static MvcHtmlString SetZenDeskLabels(this HtmlHelper html, params string[] labels)
        {   
            var keywords = string.Join(",", labels
                          .Where(label => !string.IsNullOrEmpty(label))
                          .Select(label => $"'{EscapeApostrophes(label)}'"));

            // when there are no keywords default to empty string to prevent zen desk matching articles from the url
            var apiCallString = "<script type=\"text/javascript\">zE('webWidget', 'helpCenter:setSuggestions', { labels: ["
                + (!string.IsNullOrEmpty(keywords) ? keywords : "''")
                + "] });</script>";

            return MvcHtmlString.Create(apiCallString);
        }

        private static string EscapeApostrophes(string input)
        {
            return input.Replace("'", @"\'");
        }

        public static string GetZenDeskSnippetKey(this HtmlHelper html)
        {
            return ConfigurationManager.AppSettings["ZenDeskSnippetKey"];
        }

        public static string GetZenDeskSnippetSectionId(this HtmlHelper html)
        {
            return ConfigurationManager.AppSettings["ZenDeskSectionId"];            
        }
    }
}
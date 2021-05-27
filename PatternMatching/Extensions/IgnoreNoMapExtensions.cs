﻿using AutoMapper;
using PatternMatching.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PatternMatching.Extensions
{
    public static class IgnoreNoMapExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreNoMap<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceType = typeof(TSource);
            foreach (var property in sourceType.GetProperties())
            {
                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(sourceType)[property.Name];
                NoMapAttribute attribute = (NoMapAttribute)descriptor.Attributes[typeof(NoMapAttribute)];
                if (attribute != null)
                    expression.ForMember(property.Name, opt => opt.Ignore());
            }
            return expression;
        }
    }
}
﻿// <copyright file="HumanizeGaugeMetricFormatter.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

using System;
using System.Text;
using App.Metrics.Gauge;

namespace App.Metrics.Formatting.Humanize
{
    // TODO: Remove in 2.0.0
    [Obsolete("Replaced with formatting packages which can be used with the Report Runner")]
    public sealed class HumanizeGaugeMetricFormatter : ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null)
            {
                return string.Empty;
            }

            if (!(arg is GaugeValueSource))
            {
                return arg.ToString();
            }

            var gauge = (GaugeValueSource)arg;

            var sb = new StringBuilder();

            sb.HumanizeGauge(gauge);

            return sb.ToString();
        }
    }
}
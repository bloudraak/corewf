﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Microsoft.CoreWf;
using Microsoft.CoreWf.Statements;
using System.Linq.Expressions;
using Test.Common.TestObjects.Activities.Tracing;

namespace Test.Common.TestObjects.Activities
{
    public class TestTerminateWorkflow : TestActivity
    {
        public TestTerminateWorkflow()
        {
            this.ProductActivity = new TerminateWorkflow();
            this.ExpectedOutcome = new TerminateOutcome();
        }

        public TestTerminateWorkflow(string displayName)
            : this()
        {
            this.DisplayName = displayName;
        }

        private TerminateWorkflow ProductTerminateWorkflow
        {
            get
            {
                return (TerminateWorkflow)this.ProductActivity;
            }
        }

        public Expression<Func<ActivityContext, Exception>> ExceptionExpression
        {
            set
            {
                this.ProductTerminateWorkflow.Exception = new InArgument<Exception>(value);
            }
        }

        public string Reason
        {
            set
            {
                this.ProductTerminateWorkflow.Reason = new InArgument<string>(value);
            }
        }

        public TestActivity ReasonActivity
        {
            set
            {
                this.ProductTerminateWorkflow.Reason = new InArgument<string>((Activity<string>)value.ProductActivity);
            }
        }

        public TestActivity ExceptionActivity
        {
            set
            {
                this.ProductTerminateWorkflow.Exception = new InArgument<Exception>((Activity<Exception>)value.ProductActivity);
            }
        }
    }

    public class TerminateOutcome : Outcome
    {
        public TerminateOutcome() :
            base(OutcomeState.Completed, OutcomeState.Faulted)
        {
        }
    }
}

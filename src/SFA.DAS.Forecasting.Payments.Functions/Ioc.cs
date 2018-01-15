﻿using SFA.DAS.Messaging.POC.Infrastructure.Registries;
using StructureMap;

namespace SFA.DAS.Forecasting.Payments.Functions
{
    public class Ioc
    {
        private static IContainer container;
        private static readonly object LockObject = new object();

        public static IContainer Container
        {
            get
            {
                lock (LockObject)
                {
                    if (container == null)
                        container = new Container(c =>
                        {
                            c.AddRegistry(new MessagingRegistry());
                            
                        });
                }

                return container;
            }
        }
    }
}
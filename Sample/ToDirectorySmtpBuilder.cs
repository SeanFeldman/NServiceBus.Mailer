﻿using System;
using System.IO;
using System.Net.Mail;
using NServiceBus.Mailer;

public class ToDirectorySmtpBuilder : ISmtpBuilder
{
    public SmtpClient BuildClient()
    {
        var directoryLocation = Path.Combine(Environment.CurrentDirectory, "Emails");
        Directory.CreateDirectory(directoryLocation);
        return new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = directoryLocation
            };
    }
}
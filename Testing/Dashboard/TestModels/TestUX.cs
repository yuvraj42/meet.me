﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard;
using Dashboard.Client.SessionManagement;

namespace Testing.Dashboard.TestModels
{
    class TestUX : IClientSessionNotifications
    {
        public TestUX(IUXClientSessionManager sessionManager)
        {
            _sessionManager = sessionManager;
            gotNotified = false;
            _sessionManager.SummaryCreated += (summary) => UpdateSummary(summary);
            summary = null;
        }
        public void OnClientSessionChanged(SessionData session)
        {
            sessionData = session;
            Console.WriteLine(session);
            gotNotified = true;
        }

        private void UpdateSummary(string recievedSummary)
        {
            summary = recievedSummary;
        }

        public string summary;
        public bool gotNotified;
        private IUXClientSessionManager _sessionManager;
        public SessionData sessionData;
    }
}

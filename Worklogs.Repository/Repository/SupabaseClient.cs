using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worklogs.Repository.Repository
{
    public class SupabaseClient
    {
        private readonly Client client;

        public SupabaseClient()
        {
            var url = "https://gafntrycdymlfuedfexr.supabase.co";
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImdhZm50cnljZHltbGZ1ZWRmZXhyIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NjA5MjI4MTksImV4cCI6MjA3NjQ5ODgxOX0.J6tGo5jPKXp7CqODuFzsYbhW1JltLYmj50Vww_ci320";

            client = new Client(url, key);
        }

        public Client GetClient() => client;
    }
}

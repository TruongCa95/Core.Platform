namespace BuildingBlocks.Security;

public static class PermissionCatalog
{
    public static class Timesheet
    {
        public static class Dashboard
        {
            public const string View = "timesheet:dashboard:view";
            public const string Write = "timesheet:dashboard:write";
        }

        public static class Student
        {
            public const string View = "timesheet:student:view";
            public const string Write = "timesheet:student:write";
        }

        public static class Classroom
        {
            public const string View = "timesheet:classroom:view";
            public const string Write = "timesheet:classroom:write";
        }

        public static class Salary
        {
            public const string View = "timesheet:salary:view";
            public const string Write = "timesheet:salary:write";
        }

        public static class Kpi
        {
            public const string View = "timesheet:kpi:view";
            public const string Write = "timesheet:kpi:write";
        }
    }
}

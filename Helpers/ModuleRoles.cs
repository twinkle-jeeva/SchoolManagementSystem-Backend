using System.Collections.Generic;

namespace StudentDemoAPI.Helpers
{
    public static class ModuleRoles
    {
        public static readonly Dictionary<string, string[]> RolesPerModule = new()
        {
            { "users", new[] { Roles.Admin } },
            { "students", new[] { Roles.Admin, Roles.Teacher, Roles.Student } },
            { "teachers", new[] { Roles.Admin } },
            { "parents", new[] { Roles.Admin, Roles.Teacher } },
            { "emergencycontacts", new[] { Roles.Admin, Roles.Teacher, Roles.Parent } },
            { "courses", new[] { Roles.Admin, Roles.Teacher } },
            { "subjects", new[] { Roles.Admin, Roles.Teacher } }
        };
    }
}
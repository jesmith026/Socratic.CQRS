using System;
using System.Collections.Generic;
using System.Linq;
using api.Exceptions;

namespace api.Data
{
    public static class DbMock
    {
        private static List<object> Data;

        static DbMock()
        {
            var mathCourse = new Course {
                Id = 0,
                Name = "Discrete Mathematics"
            };
            var csCourse = new Course {
                Id = 1,
                Name = "Database Architecture"
            };

            Data = new List<object> {
                new Student {
                    Id = 0,
                    Name = "James",
                    Courses = new List<Course> {
                        mathCourse,
                        csCourse
                    }
                },
                new Student {
                    Id = 1,
                    Name = "Zane",
                    Courses = new List<Course> {
                        mathCourse
                    }
                },
                new Student {
                    Id = 2,
                    Name = "Liyana",
                    Courses = new List<Course> {
                        csCourse
                    }
                }
            };
        }

        public static IEnumerable<T> GetAll<T>() where T : IEntity {
            return Data.OfType<T>();
        }

        public static T FindOne<T>(int id) where T : IEntity {
            return Data.OfType<T>()
                .SingleOrDefault(x => x.Id == id);
        }

        public static T FindOne<T>(T record) where T : IEntity {
            return FindOne<T>(record.Id);
        }        

        public static void Add<T>(T record) where T : IEntity {
            if (FindOne<T>(record.Id) != null)
                throw new DuplicateObjectException(record);
            
            Data.Add(record);
        }

        public static void Update<T>(T record) where T : IEntity {
            var existingObj = FindOne<T>(record.Id);

            if (existingObj == null)
                Add(record);
            else {
                Data.Remove(existingObj);
                Data.Add(record);
            }
        }

        public static void Delete<T>(int id) where T : IEntity {
            var existingObj = FindOne<T>(id);

            if (existingObj != null)
                Data.Remove(existingObj);
        }

        public static void Delete<T>(T record) where T : IEntity {
            Delete<T>(record.Id);
        }
    }    
}
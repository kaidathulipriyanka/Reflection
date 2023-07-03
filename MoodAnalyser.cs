using System;
using System.Reflection;

namespace MoodAnalyser
{
    public class MoodAnalyser
    {
        private string message;

        public MoodAnalyser()
        {
            message = string.Empty;
        }

        public MoodAnalyser(string message)
        {
            this.message = message;
        }

        public string AnalyseMood()
        {
            if (message.Contains("Sad"))
                return "SAD";
            else
                return "HAPPY";
        }
    }

    public class MoodAnalysisException : Exception
    {
        public enum ExceptionType
        {
            NULL_MOOD,
            EMPTY_MOOD,
            NO_SUCH_CLASS,
            NO_SUCH_METHOD,
            NO_SUCH_FIELD
        }

        private readonly ExceptionType type;

        public MoodAnalysisException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }

    public class MoodAnalyserFactory
    {
        public static MoodAnalyser CreateMoodAnalyser()
        {
            Type type = typeof(MoodAnalyser);
            ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
            MoodAnalyser moodAnalyser = (MoodAnalyser)constructor.Invoke(null);
            return moodAnalyser;
        }

        public static MoodAnalyser CreateMoodAnalyser(string message)
        {
            Type type = typeof(MoodAnalyser);
            ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(string) });
            MoodAnalyser moodAnalyser = (MoodAnalyser)constructor.Invoke(new object[] { message });
            return moodAnalyser;
        }

        public static object InvokeMethod(string methodName, string message)
        {
            Type type = typeof(MoodAnalyser);
            try
            {
                MoodAnalyser moodAnalyser = CreateMoodAnalyser(message);
                MethodInfo method = type.GetMethod(methodName);
                object result = method.Invoke(moodAnalyser, null);
                return result;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "No such method found");
            }
        }

        public static void SetFieldValue(string fieldName, string message)
        {
            try
            {
                MoodAnalyser moodAnalyser = CreateMoodAnalyser();
                Type type = typeof(MoodAnalyser);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
                if (field != null)
                {
                    field.SetValue(moodAnalyser, message);
                }
                else
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_FIELD, "No such field found");
                }
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_FIELD, "No such field found");
            }
        }
    }

    public class MoodAnalyserReflector
    {
        public static object InvokeMethodUsingReflector(string methodName, string message)
        {
            Type type = typeof(MoodAnalyser);
            try
            {
                MoodAnalyser moodAnalyser = MoodAnalyserFactory.CreateMoodAnalyser(message);
                MethodInfo method = type.GetMethod(methodName);
                object result = method.Invoke(moodAnalyser, null);
                return result;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "No such method found");
            }
        }

        public static void SetFieldValueUsingReflector(string fieldName, string message)
        {
            try
            {
                MoodAnalyser moodAnalyser = MoodAnalyserFactory.CreateMoodAnalyser();
                Type type = typeof(MoodAnalyser);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
                if (field != null)
                {
                    field.SetValue(moodAnalyser, message);
                }
                else
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_FIELD, "No such field found");
                }
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_FIELD, "No such field found");
            }
        }
    }

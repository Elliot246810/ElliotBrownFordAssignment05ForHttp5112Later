using System;
using System.Reflection;

namespace ElliotBrownFordAssignment03ForHttp5112.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}
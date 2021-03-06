﻿/*
   Copyright 2011 Michael Edwards
 
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glass.Sitecore.Mapper.Configuration.Attributes
{

    /// <summary>
    /// Indicates that the .Net class can be loaded by Glass.Sitecore.Mapper
    /// </summary>
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Interface)]
    public class SitecoreClassAttribute : Attribute
    {
        /// <summary>
        /// Indicates that the class can be used by Glass Sitecore Mapper
        /// </summary>
        public SitecoreClassAttribute()
        {
        }

        public SitecoreClassAttribute(bool codeFirst, string templateId)
        {
            TemplateId = templateId;
            CodeFirst = codeFirst;
        }
        
        /// <summary>
        /// Indicates the template to use when trying to create an item
        /// </summary>
        public string TemplateId { get; set; }
        /// <summary>
        /// Indicates the branch to use when trying to create and item. If a template id is also specified the template Id will be use instead.
        /// </summary>
        public string BranchId { get; set; }

        /// <summary>
        /// Indicates that the class is used in a code first scenario.
        /// </summary>
        public bool CodeFirst { get; set; }

        /// <summary>
        /// Overrides the default template name when using code first
        /// </summary>
        public string TemplateName { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;

namespace MDR_Downloader.ctg
{
    /*
    public class nct_response
    {
        public FullStudiesResponse? JSON { get; set; }
    }


    public class FullStudiesResponse
    {
        public string? APIVrs { get; set; }
        public string? DataVrs { get; set; }
        public string? Expression { get; set; }
        public int NStudiesAvail { get; set; }
        public int NStudiesFound { get; set; }
        public int MinRank { get; set; }
        public int MaxRank { get; set; }
        public int NStudiesReturned { get; set; }

        public List<StudyPlus>? FullStudyList { get; set; }
    }


    public class StudyPlus
    {
        public int rank { get; set; }
        public FullStudy? study { get; set; }
    }
    */

    /*
    public class ctg_basics
    {
        public string? sd_sid { get; set; }
        public DateTime? last_updated { get; set; }
        public string? file_name { get; set; }
        public string? file_path { get; set; }
        public string? remote_url { get; set; }
    }
    */


    /*
    //------------------------------------------------------------------------------
    // <auto-generated>
    //     This code was generated by a tool.
    //     Runtime Version:4.0.30319.42000
    //
    //     Changes to this file may cause incorrect behavior and will be lost if
    //     the code is regenerated.
    // </auto-generated>
    //------------------------------------------------------------------------------


    // 
    // This source code was auto-generated by xsd, Version=4.8.3928.0.
    // 


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class FullStudy
    {

        private StructType? structField;

        private string? rankField;

        /// <remarks/>
        public StructType? Struct
        {
            get
            {
                return this.structField;
            }
            set
            {
                this.structField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string? Rank
        {
            get
            {
                return this.rankField;
            }
            set
            {
                this.rankField = value;
            }
        }
    }


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class StructType
    {

        private object[]? itemsField;

        private string? nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Field", typeof(FieldType))]
        [System.Xml.Serialization.XmlElementAttribute("List", typeof(ListType))]
        [System.Xml.Serialization.XmlElementAttribute("Struct", typeof(StructType))]
        public object[]? Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string? Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FieldType
    {

        private string? nameField;

        private string? valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string? Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string? Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ListType
    {

        private object[]? itemsField;

        private string? nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Field", typeof(FieldType))]
        [System.Xml.Serialization.XmlElementAttribute("List", typeof(ListType))]
        [System.Xml.Serialization.XmlElementAttribute("Struct", typeof(StructType))]
        public object[]? Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string? Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }
    */

}
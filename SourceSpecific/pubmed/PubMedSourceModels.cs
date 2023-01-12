﻿using MDR_Downloader.euctr;
using Microsoft.FSharp.Core;
using System.ComponentModel;
using System.Xml.Serialization;

namespace MDR_Downloader.pubmed;

[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[XmlRoot(Namespace = "", IsNullable = false)]
public class PubmedArticleSet
{
    [XmlElement("PubmedArticle")]
    public PubmedArticle[]? PubmedArticles { get; set; }

}

[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class PubmedArticle
{
    public Citation? MedlineCitation { get; set; }
    public PubmedData? PubmedData { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class Citation
{
    [XmlAttribute()]
    public string Status { get; set; }

    [XmlAttribute()]
    public string Owner { get; set; }

    [XmlAttribute()]
    public int VersionID { get; set; }

    public PMID? PMID { get; set; }
    public CitationDate? DateCompleted { get; set; }
    public CitationDate? DateRevised { get; set; }
    public CitationArticle? Article { get; set; }
    public MedlineJournalInfo? MedlineJournalInfo { get; set; }

    public Chemical[]? ChemicalList { get; set; }
    public SuppMeshList? SupplMeshList { get; set; }
    public CommentsCorrections[]? CommentsCorrectionsList { get; set; }
    public MeshHeading[]? MeshHeadingList { get; set; }
    public KeywordList? KeywordList { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class PMID
{
    [XmlAttribute()]
    public int Version { get; set; }

    [XmlText()]
    public int Value { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class CitationDate
{
    public int? Year { get; set; }
    public int? Month { get; set; }
    public int? Day { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class CitationArticle
{
    [XmlAttribute()]
    public string PubModel { get; set; }

    public Journal? Journal { get; set; }
    public string? ArticleTitle { get; set; }
    public string? VernacularTitle { get; set; }
    public Pagination? Pagination { get; set; }

    [XmlElement("ELocationID")]
    public ELocationID[]? ELocationIDs { get; set; }

    [XmlElement("OtherID")]
    public OtherId[]? OtherIDs { get; set; }

    public AuthorList? AuthorList { get; set; }
    public PublicationType[]? PublicationTypeList { get; set; }

    [XmlElement("ArticleDate")]
    public ArticleDate? ArticleDate { get; set; }

    [XmlElement("Language")]
    public string[]? Languages { get; set; }

    public DataBankList? DataBankList { get; set; }
    public GrantList? GrantList { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class Journal
{
    public JournalISSN? ISSN { get; set; }
    public JournalIssue? JournalIssue { get; set; }
    public string? Title { get; set; }
    public string? ISOAbbreviation { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class JournalISSN
{
    [XmlAttribute()]
    public string? IssnType { get; set; }

    [XmlText()]
    public string Value { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class JournalIssue
{
    [XmlAttribute()]
    public string CitedMedium { get; set; }

    public string? Volume { get; set; }
    public string? Issue { get; set; }
    public IssuePubDate? PubDate { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class IssuePubDate
{
    public int? Year { get; set; }
    public string? Month { get; set; }
    public int? Day { get; set; }

    public string? MedlineDate { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class Pagination
{
    public string? MedlinePgn { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class ELocationID
{
    [XmlAttribute()]
    public string EIdType { get; set; }

    [XmlAttribute()]
    public string ValidYN { get; set; }

    [XmlText()]
    public string Value { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class AuthorList
{
    [XmlAttribute()]
    public string CompleteYN { get; set; }    
    
    [XmlElement("Author", IsNullable = false)]
    public Author[]? Author { get; set; }
}



[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class Author
{
    public string? CollectiveName { get; set; }
    public string? LastName { get; set; }
    public string? ForeName { get; set; }
    public string? Suffix { get; set; }
    public string? Initials { get; set; }
    public Identifier? Identifier { get; set; }

    [XmlElement("AffiliationInfo")]
    public AuthorAffiliationInfo[]? Affiliations { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class Identifier
{
    [XmlAttribute()]
    public string Source { get; set; }

    [XmlText()]
    public string Value { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class AuthorAffiliationInfo
{
    public string? Affiliation { get; set; }
    public Identifier? Identifier { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class DataBankList
{
    [XmlElement("DataBank")]
    public DataBank[]? DataBanks { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class DataBank
{
    public string? DataBankName { get; set; }

    [XmlArrayItem("AccessionNumber", IsNullable = false)]
    public string[]? AccessionNumberList { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class GrantList
{
    [XmlAttribute()]
    public string CompleteYN { get; set; }

    [XmlElement("Grant", IsNullable = false)]
    public Grant[]? Grant { get; set; }

}

[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class Grant
{
    public string? GrantID { get; set; }
    public string? Acronym { get; set; }
    public string? Agency { get; set; }
    public string? Country { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class PublicationType
{
    [XmlAttribute()]
    public string UI { get; set; }

    [XmlText()]
    public string Value { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class ArticleDate
{
    public int? Year { get; set; }
    public int? Month { get; set; }
    public int? Day { get; set; }

    [XmlAttribute()]
    public string DateType { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class MedlineJournalInfo
{
    public string? Country { get; set; }
    public string? MedlineTA { get; set; }
    public string? NlmUniqueID { get; set; }
    public string? ISSNLinking { get; set; }
}

[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class OtherId
{
    [XmlAttribute()]
    public string Source { get; set; }
    [XmlText()]
    public string Value { get; set; }
}

[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class Chemical
{
    public NameOfSubstance? NameOfSubstance { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class NameOfSubstance
{
    [XmlAttribute()]
    public string UI { get; set; }

    [XmlText()]
    public string Value { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class SuppMeshList
{
    [XmlArrayItem("SupplMeshName", IsNullable = false)]
    public SupplMeshName[]? SupplMeshName { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class SupplMeshName
{
    [XmlAttribute()]
    public string Type { get; set; }

    [XmlAttribute()]
    public string UI { get; set; }

    [XmlText()]
    public string Value { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class CommentsCorrections
{
    [XmlAttribute()]
    public string RefType { get; set; }

    public string? RefSource { get; set; }
    public CCPMID? PMID { get; set; }
    public string? Note { get; set; }
}

[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class CCPMID
{
    [XmlAttribute()]
    public int Version { get; set; }

    [XmlText()]
    public int Value { get; set; }
}

[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class MeshHeading
{
    public DescriptorName? DescriptorName { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class DescriptorName
{
    [XmlAttribute()]
    public string UI { get; set; }
    
    [XmlAttribute()]
    public string MajorTopicYN { get; set; }
    
    [XmlAttribute()]
    public string Type { get; set; }
    
    [XmlText()]
    public string Value { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class KeywordList
{
    [XmlAttribute()]
    public string Owner { get; set; }

    [XmlElement("Keyword")]
    public Keyword[]? Keyword { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class Keyword
{
    [XmlAttribute()]
    public string MajorTopicYN { get; set; }

    [XmlText()]
    public string Value { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class PubmedData
{
    [XmlArrayItem("PubMedPubDate", IsNullable = false)]
    public PubMedPubDate[]? History { get; set; }

    public string? PublicationStatus { get; set; }

    [XmlArrayItem("ArticleId", IsNullable = false)]
    public PubmedDataArticleId[]? ArticleIdList { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class PubMedPubDate
{
    [XmlAttribute()]
    public string PubStatus { get; set; }

    public int? Year { get; set; }
    public int? Month { get; set; }
    public int? Day { get; set; }
}


[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class PubmedDataArticleId
{
    [XmlAttribute()]
    public string IdType { get; set; }

    [XmlText()]
    public string Value { get; set; }
}



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
// This source code was auto-generated by xsd, Version=4.7.3081.0.
// 
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true)]
[XmlRootAttribute(Namespace = "", IsNullable = false)]

public partial class eSearchResult
{
    public int Count;
    public int RetMax;
    public int RetStart;
    public int QueryKey;
    public string WebEnv;
    public object TranslationSet;
    public string QueryTranslation;
    public eSearchResultTranslationStack TranslationStack;

    [XmlArrayItemAttribute("Id", IsNullable = false)]
    public int[] IdList;
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true)]
public partial class eSearchResultTranslationStack
{
    public eSearchResultTranslationStackTermSet TermSet;
    public string OP;
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true)]
public partial class eSearchResultTranslationStackTermSet
{
    public string Term;
    public string Field;
    public int Count;
    public string Explode;
}

public partial class ePostResult
{
    public int QueryKey;
    public string WebEnv;
}




/*
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class PubmedArticleSet
{

    private PubmedArticleSetPubmedArticle[] pubmedArticleField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PubmedArticle")]
    public PubmedArticleSetPubmedArticle[] PubmedArticle
    {
        get
        {
            return this.pubmedArticleField;
        }
        set
        {
            this.pubmedArticleField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticle
{

    private PubmedArticleSetPubmedArticleMedlineCitation medlineCitationField;

    private PubmedArticleSetPubmedArticlePubmedData pubmedDataField;

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitation MedlineCitation
    {
        get
        {
            return this.medlineCitationField;
        }
        set
        {
            this.medlineCitationField = value;
        }
    }

    /// <remarks/>
    public PubmedArticleSetPubmedArticlePubmedData PubmedData
    {
        get
        {
            return this.pubmedDataField;
        }
        set
        {
            this.pubmedDataField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitation
{

    private PubmedArticleSetPubmedArticleMedlineCitationPMID pMIDField;

    private PubmedArticleSetPubmedArticleMedlineCitationDateCompleted dateCompletedField;

    private PubmedArticleSetPubmedArticleMedlineCitationDateRevised dateRevisedField;

    private PubmedArticleSetPubmedArticleMedlineCitationArticle articleField;

    private PubmedArticleSetPubmedArticleMedlineCitationMedlineJournalInfo medlineJournalInfoField;

    private PubmedArticleSetPubmedArticleMedlineCitationChemical[] chemicalListField;

    private PubmedArticleSetPubmedArticleMedlineCitationSupplMeshList supplMeshListField;

    private string citationSubsetField;

    private PubmedArticleSetPubmedArticleMedlineCitationCommentsCorrections[] commentsCorrectionsListField;

    private PubmedArticleSetPubmedArticleMedlineCitationMeshHeading[] meshHeadingListField;

    private PubmedArticleSetPubmedArticleMedlineCitationKeywordList keywordListField;

    private PubmedArticleSetPubmedArticleMedlineCitationInvestigator[] investigatorListField;

    private string coiStatementField;

    private string statusField;

    private string ownerField;

    private string indexingMethodField;

    private byte versionIDField;

    private bool versionIDFieldSpecified;

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationPMID PMID
    {
        get
        {
            return this.pMIDField;
        }
        set
        {
            this.pMIDField = value;
        }
    }

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationDateCompleted DateCompleted
    {
        get
        {
            return this.dateCompletedField;
        }
        set
        {
            this.dateCompletedField = value;
        }
    }

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationDateRevised DateRevised
    {
        get
        {
            return this.dateRevisedField;
        }
        set
        {
            this.dateRevisedField = value;
        }
    }

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationArticle Article
    {
        get
        {
            return this.articleField;
        }
        set
        {
            this.articleField = value;
        }
    }

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationMedlineJournalInfo MedlineJournalInfo
    {
        get
        {
            return this.medlineJournalInfoField;
        }
        set
        {
            this.medlineJournalInfoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Chemical", IsNullable = false)]
    public PubmedArticleSetPubmedArticleMedlineCitationChemical[] ChemicalList
    {
        get
        {
            return this.chemicalListField;
        }
        set
        {
            this.chemicalListField = value;
        }
    }

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationSupplMeshList SupplMeshList
    {
        get
        {
            return this.supplMeshListField;
        }
        set
        {
            this.supplMeshListField = value;
        }
    }

    /// <remarks/>
    public string CitationSubset
    {
        get
        {
            return this.citationSubsetField;
        }
        set
        {
            this.citationSubsetField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("CommentsCorrections", IsNullable = false)]
    public PubmedArticleSetPubmedArticleMedlineCitationCommentsCorrections[] CommentsCorrectionsList
    {
        get
        {
            return this.commentsCorrectionsListField;
        }
        set
        {
            this.commentsCorrectionsListField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("MeshHeading", IsNullable = false)]
    public PubmedArticleSetPubmedArticleMedlineCitationMeshHeading[] MeshHeadingList
    {
        get
        {
            return this.meshHeadingListField;
        }
        set
        {
            this.meshHeadingListField = value;
        }
    }

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationKeywordList KeywordList
    {
        get
        {
            return this.keywordListField;
        }
        set
        {
            this.keywordListField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Investigator", IsNullable = false)]
    public PubmedArticleSetPubmedArticleMedlineCitationInvestigator[] InvestigatorList
    {
        get
        {
            return this.investigatorListField;
        }
        set
        {
            this.investigatorListField = value;
        }
    }

    /// <remarks/>
    public string CoiStatement
    {
        get
        {
            return this.coiStatementField;
        }
        set
        {
            this.coiStatementField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Status
    {
        get
        {
            return this.statusField;
        }
        set
        {
            this.statusField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Owner
    {
        get
        {
            return this.ownerField;
        }
        set
        {
            this.ownerField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string IndexingMethod
    {
        get
        {
            return this.indexingMethodField;
        }
        set
        {
            this.indexingMethodField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte VersionID
    {
        get
        {
            return this.versionIDField;
        }
        set
        {
            this.versionIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool VersionIDSpecified
    {
        get
        {
            return this.versionIDFieldSpecified;
        }
        set
        {
            this.versionIDFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationPMID
{

    private byte versionField;

    private uint valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte Version
    {
        get
        {
            return this.versionField;
        }
        set
        {
            this.versionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public uint Value
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
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationDateCompleted
{

    private ushort yearField;

    private byte monthField;

    private byte dayField;

    /// <remarks/>
    public ushort Year
    {
        get
        {
            return this.yearField;
        }
        set
        {
            this.yearField = value;
        }
    }

    /// <remarks/>
    public byte Month
    {
        get
        {
            return this.monthField;
        }
        set
        {
            this.monthField = value;
        }
    }

    /// <remarks/>
    public byte Day
    {
        get
        {
            return this.dayField;
        }
        set
        {
            this.dayField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationDateRevised
{

    private ushort yearField;

    private byte monthField;

    private byte dayField;

    /// <remarks/>
    public ushort Year
    {
        get
        {
            return this.yearField;
        }
        set
        {
            this.yearField = value;
        }
    }

    /// <remarks/>
    public byte Month
    {
        get
        {
            return this.monthField;
        }
        set
        {
            this.monthField = value;
        }
    }

    /// <remarks/>
    public byte Day
    {
        get
        {
            return this.dayField;
        }
        set
        {
            this.dayField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationArticle
{

    private PubmedArticleSetPubmedArticleMedlineCitationArticleJournal journalField;

    private string articleTitleField;

    private PubmedArticleSetPubmedArticleMedlineCitationArticlePagination paginationField;

    private PubmedArticleSetPubmedArticleMedlineCitationArticleELocationID[] eLocationIDField;

    private PubmedArticleSetPubmedArticleMedlineCitationArticleAbstract abstractField;

    private PubmedArticleSetPubmedArticleMedlineCitationArticleAuthorList authorListField;

    private string languageField;

    private PubmedArticleSetPubmedArticleMedlineCitationArticleDataBankList dataBankListField;

    private PubmedArticleSetPubmedArticleMedlineCitationArticleGrantList grantListField;

    private PubmedArticleSetPubmedArticleMedlineCitationArticlePublicationType[] publicationTypeListField;

    private PubmedArticleSetPubmedArticleMedlineCitationArticleArticleDate articleDateField;

    private string pubModelField;

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationArticleJournal Journal
    {
        get
        {
            return this.journalField;
        }
        set
        {
            this.journalField = value;
        }
    }

    /// <remarks/>
    public string ArticleTitle
    {
        get
        {
            return this.articleTitleField;
        }
        set
        {
            this.articleTitleField = value;
        }
    }

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationArticlePagination Pagination
    {
        get
        {
            return this.paginationField;
        }
        set
        {
            this.paginationField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ELocationID")]
    public PubmedArticleSetPubmedArticleMedlineCitationArticleELocationID[] ELocationID
    {
        get
        {
            return this.eLocationIDField;
        }
        set
        {
            this.eLocationIDField = value;
        }
    }

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationArticleAbstract Abstract
    {
        get
        {
            return this.abstractField;
        }
        set
        {
            this.abstractField = value;
        }
    }

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationArticleAuthorList AuthorList
    {
        get
        {
            return this.authorListField;
        }
        set
        {
            this.authorListField = value;
        }
    }

    /// <remarks/>
    public string Language
    {
        get
        {
            return this.languageField;
        }
        set
        {
            this.languageField = value;
        }
    }

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationArticleDataBankList DataBankList
    {
        get
        {
            return this.dataBankListField;
        }
        set
        {
            this.dataBankListField = value;
        }
    }

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationArticleGrantList GrantList
    {
        get
        {
            return this.grantListField;
        }
        set
        {
            this.grantListField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("PublicationType", IsNullable = false)]
    public PubmedArticleSetPubmedArticleMedlineCitationArticlePublicationType[] PublicationTypeList
    {
        get
        {
            return this.publicationTypeListField;
        }
        set
        {
            this.publicationTypeListField = value;
        }
    }

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationArticleArticleDate ArticleDate
    {
        get
        {
            return this.articleDateField;
        }
        set
        {
            this.articleDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string PubModel
    {
        get
        {
            return this.pubModelField;
        }
        set
        {
            this.pubModelField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationArticleJournal
{

    private PubmedArticleSetPubmedArticleMedlineCitationArticleJournalISSN iSSNField;

    private PubmedArticleSetPubmedArticleMedlineCitationArticleJournalJournalIssue journalIssueField;

    private string titleField;

    private string iSOAbbreviationField;

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationArticleJournalISSN ISSN
    {
        get
        {
            return this.iSSNField;
        }
        set
        {
            this.iSSNField = value;
        }
    }

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationArticleJournalJournalIssue JournalIssue
    {
        get
        {
            return this.journalIssueField;
        }
        set
        {
            this.journalIssueField = value;
        }
    }

    /// <remarks/>
    public string Title
    {
        get
        {
            return this.titleField;
        }
        set
        {
            this.titleField = value;
        }
    }

    /// <remarks/>
    public string ISOAbbreviation
    {
        get
        {
            return this.iSOAbbreviationField;
        }
        set
        {
            this.iSOAbbreviationField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationArticleJournalISSN
{

    private string issnTypeField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string IssnType
    {
        get
        {
            return this.issnTypeField;
        }
        set
        {
            this.issnTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
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
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationArticleJournalJournalIssue
{

    private ushort volumeField;

    private byte issueField;

    private bool issueFieldSpecified;

    private PubmedArticleSetPubmedArticleMedlineCitationArticleJournalJournalIssuePubDate pubDateField;

    private string citedMediumField;

    /// <remarks/>
    public ushort Volume
    {
        get
        {
            return this.volumeField;
        }
        set
        {
            this.volumeField = value;
        }
    }

    /// <remarks/>
    public byte Issue
    {
        get
        {
            return this.issueField;
        }
        set
        {
            this.issueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IssueSpecified
    {
        get
        {
            return this.issueFieldSpecified;
        }
        set
        {
            this.issueFieldSpecified = value;
        }
    }

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationArticleJournalJournalIssuePubDate PubDate
    {
        get
        {
            return this.pubDateField;
        }
        set
        {
            this.pubDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CitedMedium
    {
        get
        {
            return this.citedMediumField;
        }
        set
        {
            this.citedMediumField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationArticleJournalJournalIssuePubDate
{

    private ushort yearField;

    private string monthField;

    private byte dayField;

    private bool dayFieldSpecified;

    /// <remarks/>
    public ushort Year
    {
        get
        {
            return this.yearField;
        }
        set
        {
            this.yearField = value;
        }
    }

    /// <remarks/>
    public string Month
    {
        get
        {
            return this.monthField;
        }
        set
        {
            this.monthField = value;
        }
    }

    /// <remarks/>
    public byte Day
    {
        get
        {
            return this.dayField;
        }
        set
        {
            this.dayField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool DaySpecified
    {
        get
        {
            return this.dayFieldSpecified;
        }
        set
        {
            this.dayFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationArticlePagination
{

    private string startPageField;

    private string endPageField;

    private string medlinePgnField;

    /// <remarks/>
    public string StartPage
    {
        get
        {
            return this.startPageField;
        }
        set
        {
            this.startPageField = value;
        }
    }

    /// <remarks/>
    public string EndPage
    {
        get
        {
            return this.endPageField;
        }
        set
        {
            this.endPageField = value;
        }
    }

    /// <remarks/>
    public string MedlinePgn
    {
        get
        {
            return this.medlinePgnField;
        }
        set
        {
            this.medlinePgnField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationArticleELocationID
{

    private string eIdTypeField;

    private string validYNField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string EIdType
    {
        get
        {
            return this.eIdTypeField;
        }
        set
        {
            this.eIdTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ValidYN
    {
        get
        {
            return this.validYNField;
        }
        set
        {
            this.validYNField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
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
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationArticleAbstract
{

    private PubmedArticleSetPubmedArticleMedlineCitationArticleAbstractAbstractText[] abstractTextField;

    private string copyrightInformationField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractText")]
    public PubmedArticleSetPubmedArticleMedlineCitationArticleAbstractAbstractText[] AbstractText
    {
        get
        {
            return this.abstractTextField;
        }
        set
        {
            this.abstractTextField = value;
        }
    }

    /// <remarks/>
    public string CopyrightInformation
    {
        get
        {
            return this.copyrightInformationField;
        }
        set
        {
            this.copyrightInformationField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationArticleAbstractAbstractText
{

    private string[] itemsField;

    private ItemsChoiceType[] itemsElementNameField;

    private string[] textField;

    private string labelField;

    private string nlmCategoryField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("i", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("sub", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("sup", typeof(string))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public string[] Items
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
    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemsChoiceType[] ItemsElementName
    {
        get
        {
            return this.itemsElementNameField;
        }
        set
        {
            this.itemsElementNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text
    {
        get
        {
            return this.textField;
        }
        set
        {
            this.textField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Label
    {
        get
        {
            return this.labelField;
        }
        set
        {
            this.labelField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string NlmCategory
    {
        get
        {
            return this.nlmCategoryField;
        }
        set
        {
            this.nlmCategoryField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemsChoiceType
{

    /// <remarks/>
    i,

    /// <remarks/>
    sub,

    /// <remarks/>
    sup,
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationArticleAuthorList
{

    private PubmedArticleSetPubmedArticleMedlineCitationArticleAuthorListAuthor[] authorField;

    private string completeYNField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Author")]
    public PubmedArticleSetPubmedArticleMedlineCitationArticleAuthorListAuthor[] Author
    {
        get
        {
            return this.authorField;
        }
        set
        {
            this.authorField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CompleteYN
    {
        get
        {
            return this.completeYNField;
        }
        set
        {
            this.completeYNField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationArticleAuthorListAuthor
{

    private string collectiveNameField;

    private string lastNameField;

    private string foreNameField;

    private string initialsField;

    private PubmedArticleSetPubmedArticleMedlineCitationArticleAuthorListAuthorIdentifier identifierField;

    private PubmedArticleSetPubmedArticleMedlineCitationArticleAuthorListAuthorAffiliationInfo[] affiliationInfoField;

    private string validYNField;

    /// <remarks/>
    public string CollectiveName
    {
        get
        {
            return this.collectiveNameField;
        }
        set
        {
            this.collectiveNameField = value;
        }
    }

    /// <remarks/>
    public string LastName
    {
        get
        {
            return this.lastNameField;
        }
        set
        {
            this.lastNameField = value;
        }
    }

    /// <remarks/>
    public string ForeName
    {
        get
        {
            return this.foreNameField;
        }
        set
        {
            this.foreNameField = value;
        }
    }

    /// <remarks/>
    public string Initials
    {
        get
        {
            return this.initialsField;
        }
        set
        {
            this.initialsField = value;
        }
    }

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationArticleAuthorListAuthorIdentifier Identifier
    {
        get
        {
            return this.identifierField;
        }
        set
        {
            this.identifierField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AffiliationInfo")]
    public PubmedArticleSetPubmedArticleMedlineCitationArticleAuthorListAuthorAffiliationInfo[] AffiliationInfo
    {
        get
        {
            return this.affiliationInfoField;
        }
        set
        {
            this.affiliationInfoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ValidYN
    {
        get
        {
            return this.validYNField;
        }
        set
        {
            this.validYNField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationArticleAuthorListAuthorIdentifier
{

    private string sourceField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Source
    {
        get
        {
            return this.sourceField;
        }
        set
        {
            this.sourceField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
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
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationArticleAuthorListAuthorAffiliationInfo
{

    private string affiliationField;

    /// <remarks/>
    public string Affiliation
    {
        get
        {
            return this.affiliationField;
        }
        set
        {
            this.affiliationField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationArticleDataBankList
{

    private PubmedArticleSetPubmedArticleMedlineCitationArticleDataBankListDataBank[] dataBankField;

    private string completeYNField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("DataBank")]
    public PubmedArticleSetPubmedArticleMedlineCitationArticleDataBankListDataBank[] DataBank
    {
        get
        {
            return this.dataBankField;
        }
        set
        {
            this.dataBankField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CompleteYN
    {
        get
        {
            return this.completeYNField;
        }
        set
        {
            this.completeYNField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationArticleDataBankListDataBank
{

    private string dataBankNameField;

    private string[] accessionNumberListField;

    /// <remarks/>
    public string DataBankName
    {
        get
        {
            return this.dataBankNameField;
        }
        set
        {
            this.dataBankNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("AccessionNumber", IsNullable = false)]
    public string[] AccessionNumberList
    {
        get
        {
            return this.accessionNumberListField;
        }
        set
        {
            this.accessionNumberListField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationArticleGrantList
{

    private PubmedArticleSetPubmedArticleMedlineCitationArticleGrantListGrant[] grantField;

    private string completeYNField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Grant")]
    public PubmedArticleSetPubmedArticleMedlineCitationArticleGrantListGrant[] Grant
    {
        get
        {
            return this.grantField;
        }
        set
        {
            this.grantField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CompleteYN
    {
        get
        {
            return this.completeYNField;
        }
        set
        {
            this.completeYNField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationArticleGrantListGrant
{

    private string grantIDField;

    private string acronymField;

    private string agencyField;

    private string countryField;

    /// <remarks/>
    public string GrantID
    {
        get
        {
            return this.grantIDField;
        }
        set
        {
            this.grantIDField = value;
        }
    }

    /// <remarks/>
    public string Acronym
    {
        get
        {
            return this.acronymField;
        }
        set
        {
            this.acronymField = value;
        }
    }

    /// <remarks/>
    public string Agency
    {
        get
        {
            return this.agencyField;
        }
        set
        {
            this.agencyField = value;
        }
    }

    /// <remarks/>
    public string Country
    {
        get
        {
            return this.countryField;
        }
        set
        {
            this.countryField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationArticlePublicationType
{

    private string uiField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string UI
    {
        get
        {
            return this.uiField;
        }
        set
        {
            this.uiField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
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
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationArticleArticleDate
{

    private ushort yearField;

    private byte monthField;

    private byte dayField;

    private string dateTypeField;

    /// <remarks/>
    public ushort Year
    {
        get
        {
            return this.yearField;
        }
        set
        {
            this.yearField = value;
        }
    }

    /// <remarks/>
    public byte Month
    {
        get
        {
            return this.monthField;
        }
        set
        {
            this.monthField = value;
        }
    }

    /// <remarks/>
    public byte Day
    {
        get
        {
            return this.dayField;
        }
        set
        {
            this.dayField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string DateType
    {
        get
        {
            return this.dateTypeField;
        }
        set
        {
            this.dateTypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationMedlineJournalInfo
{

    private string countryField;

    private string medlineTAField;

    private uint nlmUniqueIDField;

    private string iSSNLinkingField;

    /// <remarks/>
    public string Country
    {
        get
        {
            return this.countryField;
        }
        set
        {
            this.countryField = value;
        }
    }

    /// <remarks/>
    public string MedlineTA
    {
        get
        {
            return this.medlineTAField;
        }
        set
        {
            this.medlineTAField = value;
        }
    }

    /// <remarks/>
    public uint NlmUniqueID
    {
        get
        {
            return this.nlmUniqueIDField;
        }
        set
        {
            this.nlmUniqueIDField = value;
        }
    }

    /// <remarks/>
    public string ISSNLinking
    {
        get
        {
            return this.iSSNLinkingField;
        }
        set
        {
            this.iSSNLinkingField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationChemical
{

    private string registryNumberField;

    private PubmedArticleSetPubmedArticleMedlineCitationChemicalNameOfSubstance nameOfSubstanceField;

    /// <remarks/>
    public string RegistryNumber
    {
        get
        {
            return this.registryNumberField;
        }
        set
        {
            this.registryNumberField = value;
        }
    }

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationChemicalNameOfSubstance NameOfSubstance
    {
        get
        {
            return this.nameOfSubstanceField;
        }
        set
        {
            this.nameOfSubstanceField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationChemicalNameOfSubstance
{

    private string uiField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string UI
    {
        get
        {
            return this.uiField;
        }
        set
        {
            this.uiField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
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
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationSupplMeshList
{

    private PubmedArticleSetPubmedArticleMedlineCitationSupplMeshListSupplMeshName supplMeshNameField;

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationSupplMeshListSupplMeshName SupplMeshName
    {
        get
        {
            return this.supplMeshNameField;
        }
        set
        {
            this.supplMeshNameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationSupplMeshListSupplMeshName
{

    private string typeField;

    private string uiField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string UI
    {
        get
        {
            return this.uiField;
        }
        set
        {
            this.uiField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
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
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationCommentsCorrections
{

    private string refSourceField;

    private PubmedArticleSetPubmedArticleMedlineCitationCommentsCorrectionsPMID pMIDField;

    private string refTypeField;

    /// <remarks/>
    public string RefSource
    {
        get
        {
            return this.refSourceField;
        }
        set
        {
            this.refSourceField = value;
        }
    }

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationCommentsCorrectionsPMID PMID
    {
        get
        {
            return this.pMIDField;
        }
        set
        {
            this.pMIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string RefType
    {
        get
        {
            return this.refTypeField;
        }
        set
        {
            this.refTypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationCommentsCorrectionsPMID
{

    private byte versionField;

    private uint valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte Version
    {
        get
        {
            return this.versionField;
        }
        set
        {
            this.versionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public uint Value
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
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationMeshHeading
{

    private PubmedArticleSetPubmedArticleMedlineCitationMeshHeadingDescriptorName descriptorNameField;

    private PubmedArticleSetPubmedArticleMedlineCitationMeshHeadingQualifierName[] qualifierNameField;

    /// <remarks/>
    public PubmedArticleSetPubmedArticleMedlineCitationMeshHeadingDescriptorName DescriptorName
    {
        get
        {
            return this.descriptorNameField;
        }
        set
        {
            this.descriptorNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("QualifierName")]
    public PubmedArticleSetPubmedArticleMedlineCitationMeshHeadingQualifierName[] QualifierName
    {
        get
        {
            return this.qualifierNameField;
        }
        set
        {
            this.qualifierNameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationMeshHeadingDescriptorName
{

    private string uiField;

    private string majorTopicYNField;

    private string typeField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string UI
    {
        get
        {
            return this.uiField;
        }
        set
        {
            this.uiField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string MajorTopicYN
    {
        get
        {
            return this.majorTopicYNField;
        }
        set
        {
            this.majorTopicYNField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
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
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationMeshHeadingQualifierName
{

    private string uiField;

    private string majorTopicYNField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string UI
    {
        get
        {
            return this.uiField;
        }
        set
        {
            this.uiField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string MajorTopicYN
    {
        get
        {
            return this.majorTopicYNField;
        }
        set
        {
            this.majorTopicYNField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
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
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationKeywordList
{

    private PubmedArticleSetPubmedArticleMedlineCitationKeywordListKeyword[] keywordField;

    private string ownerField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Keyword")]
    public PubmedArticleSetPubmedArticleMedlineCitationKeywordListKeyword[] Keyword
    {
        get
        {
            return this.keywordField;
        }
        set
        {
            this.keywordField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Owner
    {
        get
        {
            return this.ownerField;
        }
        set
        {
            this.ownerField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationKeywordListKeyword
{

    private string majorTopicYNField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string MajorTopicYN
    {
        get
        {
            return this.majorTopicYNField;
        }
        set
        {
            this.majorTopicYNField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
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
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticleMedlineCitationInvestigator
{

    private string lastNameField;

    private string foreNameField;

    private string initialsField;

    private string validYNField;

    /// <remarks/>
    public string LastName
    {
        get
        {
            return this.lastNameField;
        }
        set
        {
            this.lastNameField = value;
        }
    }

    /// <remarks/>
    public string ForeName
    {
        get
        {
            return this.foreNameField;
        }
        set
        {
            this.foreNameField = value;
        }
    }

    /// <remarks/>
    public string Initials
    {
        get
        {
            return this.initialsField;
        }
        set
        {
            this.initialsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ValidYN
    {
        get
        {
            return this.validYNField;
        }
        set
        {
            this.validYNField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticlePubmedData
{

    private PubmedArticleSetPubmedArticlePubmedDataPubMedPubDate[] historyField;

    private string publicationStatusField;

    private PubmedArticleSetPubmedArticlePubmedDataArticleId[] articleIdListField;

    private PubmedArticleSetPubmedArticlePubmedDataReference[] referenceListField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("PubMedPubDate", IsNullable = false)]
    public PubmedArticleSetPubmedArticlePubmedDataPubMedPubDate[] History
    {
        get
        {
            return this.historyField;
        }
        set
        {
            this.historyField = value;
        }
    }

    /// <remarks/>
    public string PublicationStatus
    {
        get
        {
            return this.publicationStatusField;
        }
        set
        {
            this.publicationStatusField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ArticleId", IsNullable = false)]
    public PubmedArticleSetPubmedArticlePubmedDataArticleId[] ArticleIdList
    {
        get
        {
            return this.articleIdListField;
        }
        set
        {
            this.articleIdListField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Reference", IsNullable = false)]
    public PubmedArticleSetPubmedArticlePubmedDataReference[] ReferenceList
    {
        get
        {
            return this.referenceListField;
        }
        set
        {
            this.referenceListField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticlePubmedDataPubMedPubDate
{

    private ushort yearField;

    private byte monthField;

    private byte dayField;

    private byte hourField;

    private bool hourFieldSpecified;

    private byte minuteField;

    private bool minuteFieldSpecified;

    private string pubStatusField;

    /// <remarks/>
    public ushort Year
    {
        get
        {
            return this.yearField;
        }
        set
        {
            this.yearField = value;
        }
    }

    /// <remarks/>
    public byte Month
    {
        get
        {
            return this.monthField;
        }
        set
        {
            this.monthField = value;
        }
    }

    /// <remarks/>
    public byte Day
    {
        get
        {
            return this.dayField;
        }
        set
        {
            this.dayField = value;
        }
    }

    /// <remarks/>
    public byte Hour
    {
        get
        {
            return this.hourField;
        }
        set
        {
            this.hourField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool HourSpecified
    {
        get
        {
            return this.hourFieldSpecified;
        }
        set
        {
            this.hourFieldSpecified = value;
        }
    }

    /// <remarks/>
    public byte Minute
    {
        get
        {
            return this.minuteField;
        }
        set
        {
            this.minuteField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool MinuteSpecified
    {
        get
        {
            return this.minuteFieldSpecified;
        }
        set
        {
            this.minuteFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string PubStatus
    {
        get
        {
            return this.pubStatusField;
        }
        set
        {
            this.pubStatusField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticlePubmedDataArticleId
{

    private string idTypeField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string IdType
    {
        get
        {
            return this.idTypeField;
        }
        set
        {
            this.idTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
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
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticlePubmedDataReference
{

    private string citationField;

    private PubmedArticleSetPubmedArticlePubmedDataReferenceArticleId[] articleIdListField;

    /// <remarks/>
    public string Citation
    {
        get
        {
            return this.citationField;
        }
        set
        {
            this.citationField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ArticleId", IsNullable = false)]
    public PubmedArticleSetPubmedArticlePubmedDataReferenceArticleId[] ArticleIdList
    {
        get
        {
            return this.articleIdListField;
        }
        set
        {
            this.articleIdListField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PubmedArticleSetPubmedArticlePubmedDataReferenceArticleId
{

    private string idTypeField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string IdType
    {
        get
        {
            return this.idTypeField;
        }
        set
        {
            this.idTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
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

*/
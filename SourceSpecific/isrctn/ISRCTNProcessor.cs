﻿using MDR_Downloader.Helpers;
namespace MDR_Downloader.isrctn;

public class ISRCTN_Processor
{
    public Study? GetFullDetails(FullTrial ft, ILoggingHelper logging_helper)
    {
        Study st = new();

        List<Identifier> identifiers = new();
        List<string> recruitmentCountries = new();
        List<StudyCentre> centres = new();
        List<StudyOutput> outputs = new();
        List<StudyAttachedFile> attachedFiles = new();
        List<StudyContact> contacts = new();
        List<StudySponsor> sponsors = new();
        List<StudyFunder> funders = new();
        List<string> dataPolicies = new();

        var tr = ft.trial;
        if (tr is null)
        {
            logging_helper.LogError("Unable to find ISRCTN trial data - cannot proceed");
            return null;
        }
        if (tr.isrctn?.value is null)
        {
            logging_helper.LogError("Unable to find ISRCTN value - cannot proceed");
            return null;
        }
        
        st.sd_sid = "ISRCTN" + tr.isrctn.value.ToString("00000000");
        st.dateIdAssigned = tr.isrctn?.dateAssigned;
        st.lastUpdated = tr.lastUpdated;

        var d = tr.trialDescription;
        if (d is not null)
        {
            st.title = d.title;
            st.scientificTitle = d.scientificTitle;
            st.acronym = d.acronym;
            st.studyHypothesis = d.studyHypothesis;
            st.primaryOutcome = d.primaryOutcome;
            st.secondaryOutcome = d.secondaryOutcome;
            st.trialWebsite = d.trialWebsite;
            st.ethicsApproval = d.ethicsApproval;

            string? pes = d.plainEnglishSummary;
            if (pes is not null)
            {
                // Attempt to find the beginning of the 'discarded' sections.
                // If found discard those sections.

                int endpos = pes.IndexOf("What are the possible benefits and risks", StringComparison.Ordinal);
                if (endpos == -1)
                {
                    endpos = pes.IndexOf("What are the potential benefits and risks", StringComparison.Ordinal);
                }
                if (endpos != -1)
                {
                    pes = pes[..endpos];
                }

                pes = pes.Replace("Background and study aims", "Background and study aims\n");
                pes = pes.Replace("Who can participate?", "\nWho can participate?\n");
                pes = pes.Replace("What does the study involve?", "\nWhat does the study involve?\n");
                pes = pes.CompressSpaces();
                
                st.plainEnglishSummary = pes;
            }
        }

        var g = tr.trialDesign;
        if (g is not null)
        {
            st.studyDesign = g.studyDesign;
            st.primaryStudyDesign = g.primaryStudyDesign;
            st.secondaryStudyDesign = g.secondaryStudyDesign;
            st.trialSetting = g.trialSetting;
            st.trialType = g.trialType;
            st.overallStatusOverride = g.overallStatusOverride;
            st.overallStartDate = g.overallStartDate;
            st.overallEndDate = g.overallEndDate;
        }

        var p = tr.participants;
        if (p is not null)
        {
            st.participantType = p.participantType;
            st.inclusion = p.inclusion;
            st.ageRange = p.ageRange;
            st.gender = p.gender;
            st.targetEnrolment = p.targetEnrolment;
            st.totalFinalEnrolment = p.totalFinalEnrolment;
            st.totalTarget = p.totalTarget;
            st.exclusion = p.exclusion;
            st.patientInfoSheet = p.patientInfoSheet;
            st.recruitmentStart = p.recruitmentStart;
            st.recruitmentEnd = p.recruitmentEnd;
            st.recruitmentStatusOverride = p.recruitmentStatusOverride;

            var trial_centres = p.trialCentres;
            if (trial_centres?.Any() is true)
            {
                foreach (var cr in trial_centres)
                {
                    centres.Add(new StudyCentre(cr.name, cr.address, cr.city, 
                                                cr.state, cr.country));
                }
            }

            string[]? recruitment_countries = p.recruitmentCountries;
            if (recruitment_countries?.Any() is true)
            {
                foreach(string s in recruitment_countries)
                {
                    // regularise these common alternative spellings
                    var t = s.Replace("Korea, South", "South Korea");
                    t = t.Replace("Congo, Democratic Republic", "Democratic Republic of the Congo");

                    string t2 = t.ToLower();
                    if (t2 == "england" || t2 == "scotland" ||
                                    t2 == "wales" || t2 == "northern ireland")
                    {
                         t = "United Kingdom";
                    }
                    if (t2 == "united states of america")
                    {
                         t = "United States";
                    }

                    // Check for duplicates before adding,
                    // especially after changes above

                    if (recruitmentCountries.Count == 0)
                    {
                        recruitmentCountries.Add(t);
                    }
                    else
                    {
                        bool add_country = true;
                        foreach (string cnt in recruitmentCountries)
                        {
                            if (cnt == t)
                            {
                                add_country = false;
                                break;
                            }
                        }
                        if (add_country)
                        {
                            recruitmentCountries.Add(t);
                        }
                    }
                }
            }
        }

        var c = tr.conditions?.condition;
        if (c is not null)
        {
            st.conditionDescription = c.description;
            st.diseaseClass1 = c.diseaseClass1;
            st.diseaseClass2 = c.diseaseClass2;
        }

        var i = tr.interventions?.intervention;
        if (i is not null)
        {
            st.interventionDescription = i.description;
            st.interventionType = i.interventionType;
            st.phase = i.phase;
            st.drugNames = i.drugNames;
        }

        var r = tr.results;
        if (r is not null)
        {
            st.publicationPlan = r.publicationPlan;
            st.ipdSharingStatement = r.ipdSharingStatement;
            st.intentToPublish = r.intentToPublish;
            st.publicationDetails = r.publicationDetails;
            st.publicationStage = r.publicationStage;
            st.biomedRelated = r.biomedRelated;
            st.basicReport = r.basicReport;
            st.plainEnglishReport = r.plainEnglishReport;

            var dps = r.dataPolicies;
            if (dps?.Any() is true)
            {
                foreach (string s in dps)
                {
                    dataPolicies.Add(s);
                }
            }
        }
        
        var er = tr.externalRefs;
        if (er is not null)
        {
            string? ext_ref = er.doi;
            if (!string.IsNullOrEmpty(ext_ref) && ext_ref != "N/A" 
                                               && ext_ref != "Not Applicable" && ext_ref != "Nil known")
            {
                st.doi = ext_ref;
            }

            ext_ref = er.eudraCTNumber;
            if (!string.IsNullOrEmpty(ext_ref) && ext_ref != "N/A" 
                                               && ext_ref != "Not Applicable" && ext_ref != "Nil known")
            {
                identifiers.Add(new Identifier(11, "Trial Registry ID", ext_ref, 100123, "EU Clinical Trials Register"));
            }

            ext_ref = er.irasNumber;
            if (!string.IsNullOrEmpty(ext_ref) && ext_ref != "N/A" 
                                               && ext_ref != "Not Applicable" && ext_ref != "Nil known")
            {
                identifiers.Add(new Identifier(41, "Regulatory Body ID", ext_ref, 101409, "Health Research Authority"));
            }

            ext_ref = er.clinicalTrialsGovNumber;
            if (!string.IsNullOrEmpty(ext_ref) && ext_ref != "N/A" 
                                               && ext_ref != "Not Applicable" && ext_ref != "Nil known")
            {
                identifiers.Add(new Identifier(11, "Trial Registry ID", ext_ref, 100120, "Clinicaltrials.gov"));
            }

            ext_ref = er.protocolSerialNumber;     // in fact covers many things!
            if (!string.IsNullOrEmpty(ext_ref) && ext_ref != "N/A" 
                                               && ext_ref != "Not Applicable" && ext_ref != "Nil known")
            {
                if (ext_ref.Contains(';'))
                {
                    string[] id_items = ext_ref.Split(";");
                    foreach (string id_item in id_items)
                    {
                        identifiers.Add(new Identifier(0, "To be determined", id_item.Trim(), 0, "To be determined"));
                    }
                }
                else if (ext_ref.Contains(',') && (ext_ref.ToLower().Contains("iras") || ext_ref.ToLower().Contains("hta")))
                {
                    // Don't split on commas unless these common id types are included.

                    string[] id_items = ext_ref.Split(",");
                    foreach (string id_item in id_items)
                    {
                        identifiers.Add(new Identifier(0, "To be determined", id_item.Trim(), 0, "To be determined"));
                    }
                }
                else
                {
                    identifiers.Add(new Identifier(0, "To be determined", ext_ref.Trim(), 0, "To be determined"));
                }
            }
        }

        // Do additional files first
        // so that details can be checked from the outputs data

        var afs = tr.attachedFiles;
        if (afs?.Any() is true)
        {
            foreach (var v in afs)
            {
                attachedFiles.Add(new StudyAttachedFile(v.downloadUrl, v.description, v.name, v.id, v.@public));
            }
        }

        var ops = tr.outputs;
        if (ops?.Any() is true)
        {
            foreach (var v in ops)
            {
                StudyOutput sop = new StudyOutput(v.description, v.productionNotes, v.outputType,
                            v.artefactType, v.dateCreated, v.dateUploaded, v.peerReviewed,
                            v.patientFacing, v.createdBy, v.externalLink?.url, v.localFile?.fileId,
                            v.localFile?.originalFilename, v.localFile?.downloadFilename,
                            v.localFile?.version, v.localFile?.mimeType);
                
                if (sop.artefactType == "LocalFile")
                {
                    // Check it is in the attached files list and public.

                    if (attachedFiles?.Any() is true)
                    {
                        foreach (var af in attachedFiles) 
                        { 
                            if (sop.fileId == af.id) 
                            {
                                sop.localFilePublic = af.@public;
                                sop.localFileURL = af.downloadUrl;
                                break;
                            }
                        }
                    }
                }

                outputs.Add(sop);
            }
        }

        var tr_contacts = ft.contact;
        if(tr_contacts?.Any() is true)
        {
            foreach(var v in tr_contacts)
            {
                contacts.Add(new StudyContact(v.forename, v.surname, v.orcid, v.contactType,
                             v.contactDetails?.address, v.contactDetails?.city, v.contactDetails?.country,
                             v.contactDetails?.email));
            }
        }

        var tr_sponsors = ft.sponsor;
        if (tr_sponsors?.Any() is true)
        {
            foreach (var v in tr_sponsors)
            {
                sponsors.Add(new StudySponsor(v.organisation, v.website, v.sponsorType, v.gridId,
                             v.contactDetails?.city, v.contactDetails?.country));            }
        }

        var tr_funders = ft.funder;
        if (tr_funders?.Any() is true)
        {
            foreach (var v in tr_funders)
            {
                funders.Add(new StudyFunder(v.name, v.fundRef));
            }
        }

        st.identifiers = identifiers;
        st.recruitmentCountries = recruitmentCountries;
        st.centres = centres;
        st.outputs = outputs;
        st.attachedFiles = attachedFiles;
        st.contacts = contacts;
        st.sponsors = sponsors;
        st.funders = funders;
        st.dataPolicies = dataPolicies;

        return st;
    }

}

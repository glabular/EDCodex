﻿using EDCodex.Data;
using EDCodex.Data.Enums;
using EDCodex.Data.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static EDDDLLInterfaces.EDDDLLIF;

namespace EDCodex.Panel
{
    public partial class PanelUserControl : UserControl, IEDDPanelExtension
    {
        private EDDPanelCallbacks PanelCallBack;
        private EDDCallBacks DLLCallBack;

        public PanelUserControl()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Inherit;
        }

        public bool SupportTransparency => true;

        public bool DefaultTransparent => false;

        protected Codex Codex => DbAccessor.Codex;

        public bool AllowClose() => true;

        public void DataResult(string data)
        {
            LogMessage($"System Responded:\r\n{data}");
        }

        public void Closing()
        {
            LogMessage($"Close panel {PanelCallBack.IsClosed()}");
        }

        public void ControlTextVisibleChange(bool on)
        {
        }

        public string HelpKeyOrAddress()
        {
            return @"http:\\news.bbc.co.uk";
        }

        public void HistoryChange(int count, string commander, bool beta, bool legacy)
        {
        }

        public void InitialDisplay()
        {
        }

        public void Initialise(EDDPanelCallbacks callbacks, int displayid, string themeasjson, string configuration)
        {
            DLLCallBack = CSharpDLLPanelEDDClass.DLLCallBack;
            this.PanelCallBack = callbacks;
            DLLCallBack.WriteToLogHighlight("Panel DLL Initialised");

            LogMessage("New panel initialized.");

            DbAccessor.LoadCodex();
            PopulateGalacticRegionsCombobox();

            LogMessage("Welcome to EDCodex custom panel.");
        }

        public void LoadLayout()
        {
        }

        public void NewFilteredJournal(JournalEntry je)
        {
        }

        public void NewTarget(Tuple<string, double, double, double> target)
        {
        }

        public void NewUIEvent(string jsonui)
        {
        }

        public void NewUnfilteredJournal(JournalEntry je)
        {
        }

        public void ScreenShotCaptured(string file, Size s)
        {
        }

        public void SetTransparency(bool ison, Color curcol)
        {
        }

        public void ThemeChanged(string themeasjson)
        {
        }

        public void TransparencyModeChanged(bool on)
        {
        }

        void IEDDPanelExtension.CursorChanged(JournalEntry je)
        {
            LogMessage($"Cursor changed to {je.name}");
        }

        private void LogMessage(string message)
        {
            textBox_logMsgs.AppendText($"{message}\r\n");
            textBox_logMsgs.SelectionStart = textBox_logMsgs.Text.Length;
            textBox_logMsgs.ScrollToCaret();
        }

        /// <summary>
        /// Loads all regions into the dropdown and sets the current region.
        /// </summary>
        private void PopulateGalacticRegionsCombobox()
        {
            try
            {
                comboBox_currentRegion.Items.Clear();

                foreach (GalacticRegion region in Enum.GetValues(typeof(GalacticRegion)))
                {
                    comboBox_currentRegion.Items.Add(region);
                    LogMessage($"Region added to dropdown: {region} ({(int)region})"); // [+msg]
                }

                // If Codex exists and the current region is valid, select it.
                if (Codex != null && Enum.IsDefined(typeof(GalacticRegion), Codex.CurrentRegion))
                {
                    comboBox_currentRegion.SelectedItem = Codex.CurrentRegion;
                    LogMessage($"Current galactic region selected: {Codex.CurrentRegion} ({(int)Codex.CurrentRegion})"); // [+msg]
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error populating regions:\r\n{ex.Message}");
            }
        }

        private void comboBox_currentRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_currentRegion.SelectedItem is GalacticRegion selectedRegion)
                {
                    if (Codex != null)
                    {
                        Codex.CurrentRegion = selectedRegion;
                        DbAccessor.SaveCodex();
                        LogMessage($"Current galactic region changed to: {selectedRegion}"); // [+msg]
                        
                        // TODO: hardcoded for now
                        DisplayEntriesByRegion(Codex.Stars, selectedRegion);
                    }
                    else
                    {
                        LogMessage("Codex is null. Cannot update region.");
                    }
                }
                else
                {
                    LogMessage("Selected item is not a valid GalacticRegion.");
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error changing selected region:\r\n{ex.Message}");
            }
        }

        /// <summary>
        /// Displays entries of a specified type for a given galactic region in the UI list.
        /// </summary>
        /// <typeparam name="T">The type of codex entries to display. Must implement ICodexEntry.</typeparam>
        /// <param name="codexEntries">A collection of codex entries to show.</param>
        /// <param name="galacticRegion">The galactic region to filter the entries by.</param>
        private void DisplayEntriesByRegion<T>(IEnumerable<T> codexEntries, GalacticRegion galacticRegion)
            where T : ICodexEntry
        {
            if (listView_codexEntries == null)
            {
                LogMessage("List view is not initialized.");
                return;
            }

            listView_codexEntries.Items.Clear();
            LogMessage("Table cleared");

            if (codexEntries == null || !codexEntries.Any())
            {
                LogMessage("No entries available for the selected region.");
                return;
            }

            foreach (var entry in codexEntries)
            {
                if (entry.StatusByGalacticRegion == null)
                {
                    LogMessage($"No status information is available for the entry {entry.Description}.");
                    continue;
                }

                var statusText = entry.StatusByGalacticRegion.TryGetValue(galacticRegion,out var status)
                    ? status.ToString()
                    : "[No status available]";

                var item = new ListViewItem(entry.Description);
                item.SubItems.Add(statusText);
                listView_codexEntries.Items.Add(item);
            }

            LogMessage($"{listView_codexEntries.Items.Count} entries loaded for {galacticRegion} region.");
        }
    }
}

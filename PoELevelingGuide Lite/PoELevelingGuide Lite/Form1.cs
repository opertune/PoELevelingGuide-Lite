using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PoELevelingGuide_Lite
{
    public partial class Form1 : Form
    {
        private bool mouseDown;
        private Point lastLocation;


        // Quests table
        object[][] act =
        {
            new string[]
            {
                "Speak to Nessa, Tarkleigh",
                "Zone > The Coast – Get waypoint",
                "Zone > The Mud Flats – Get Rhoa Nests",
                "Zone > The Submerged Passage – Get waypoint",
                "Waypoint > The Coast",
                "Zone > Tidal Island - Kill Hailrake",
                "Portal > Town",
                "Speak to Nessa, Bestel, Tarkleigh – Get Quicksilver flask",
                "Waypoint > The Submerged Passage  – Leave Portal near The Flooded Depths entrance",
                "Zone > The Ledge – Get waypoint",
                "Zone > The Climb - Free Navali",
                "Zone > The Lower Prison – Get waypoint",
                "Waypoint > Town – Use your Portal to The Submerged Passage",
                "The Flooded Depths – Kill The Dweller",
                "Logout",
                "Speak to Nessa, Tarkleigh",
                "Waypoint > The Lower Prison – Lab Trial",
                "Zone > The Upper Prison",
                "Zone > The Warden’s Chambers – Kill Brutus",
                "Logout",
                "Speak to Nessa, Tarkleigh",
                "Waypoint > Prisoner’s Gate",
                "Zone > The Ship Graveyard – Get waypoint (or place Portal if not found)",
                "Zone > The Ship Graveyard Cave – Get Allflame",
                "Zone > The Ship Graveyard",
                "Zone > The Cavern of Wrath – Get waypoint",
                "Waypoint (or Portal if you have one) > The Ship Graveyard – Kill Captain Fairgraves",
                "Logout",
                "Speak to Bestel, Nessa",
                "Waypoint > The Cavern of Wrath",
                "Zone > The Cavern of Anger – Kill Merveil",
                "Zone > The Southern Forest",
                "Zone > The Forest Encampment"
            },
            new string[]
            {
                "Zone > The Old Fields – Leave a Portal at The Den zone",
                "Zone > The Crossroads – Get waypoint",
                "Waypoint > Town > Take your Portal to The Old Fields",
                "Zone > The Den – Kill The Great White Beast",
                "Logout",
                "Speak to Yeena to get Quicksilver",
                "Waypoint > The Crossroads - Head North",
                "Zone > The Chamber of Sins Level 1 – Get waypoint",
                "Zone > The Chamber of Sins Level 2 – Lab Trial – Kill Fidelitas – Pick up Baleful Gem",
                "Logout",
                "Speak to Yeena, Greust",
                "Zone > The Riverways – Speak to Einhar – Get waypoint",
                "Zone > The Western Forest – Get waypoint - Follow the wall on the opposite side of road that the waypoint is on",
                "Zone > The Weaver’s Chambers – Kill The Weaver – Pick up Maligaro’s Spike",
                "Logout",
                "Speak to Silk",
                "Waypoint > The Crossroads - Head East",
                "Zone > The Broken Bridge – Kill Kraityn – Pick up amulet",
                "Logout",
                "Waypoint > The Riverways - Head North",
                "Zone > The Wetlands – Kill Oak – Pick up amulet – Get waypoint",
                "Zone > The Vaal Ruins – Break the Ancient Seal",
                "Zone > The Northern Forest",
                "Zone > The Caverns – Get waypoint",
                "Waypoint > The Western Forest - Follow the wall on side of the road that the WP is on – Kill Alira – Pick up amulet - Head west and kill Captain Arteri – Pick up Thaumetic Emblem – Break Thaumetic Seal",
                "Logout",
                "Speak to Eramir, Greust",
                "Waypoint > The Crossroads - Head South",
                "Zone > The Fellshrine Ruins",
                "Zone > The Crypt Level 1 – Lab Trial",
                "Logout",
                "Waypoint > Act 1 Town",
                "Speak to Nessa, Bestel",
                "Waypoint > Act 2 - The Caverns",
                "Zone > The Ancient Pyramid – Kill Vaal Oversoul",
                "Logout",
                "Waypoint > The City of Sarn"
            },
            new string[]
            {
                "Speak to Clarissa",
                "Zone > The Sarn Encampment",
                "Zone > The Slums",
                "Zone > The Crematorium – Get waypoint - Lab Trial – Kill Piety – Pick up Tolman’s Bracelet",
                "Logout",
                "Speak to Clarissa, Maramoa",
                "Zone > The Slums",
                "Zone > The Sewers – Pick up 3 busts (1 before WP, 2 after) – Get waypoint",
                "Zone > The Marketplace – Get waypoint",
                "Zone > The Catacombs – Lab Trial",
                "Logout",
                "Speak to Hargan",
                "Should be around level 24, look for 4 links on vendors",
                "Waypoint > The Marketplace",
                "Zone > The Battlefront – Get waypoint – Pick up Ribbon Spool",
                "Zone > The Docks – Pick up Thaumetic Sulphite",
                "Logout",
                "Waypoint > The Battlefront",
                "Zone > Solaris Temple Level 1",
                "Zone > Solaris Temple Level 2 – Get waypoint",
                "Speak to Dialla - Get the Infernal Talc",
                "Waypoint > The Sewers – Break The Undying Blockage",
                "Zone > The Ebony Barracks – Get waypoint – Kill Gravicius",
                "Zone > The Lunaris Temple Level 1 – Get waypoint",
                "Zone > The Lunaris Temple Level 2 – Kill Piety - Pick up Tower Key",
                "Logout",
                "Speak to Clarissa, Grigor, Maramoa",
                "Waypoint > Ebony Barracks - Head East",
                "Zone > Imperial Gardens - Get waypoint (follow path) – Lab Trial",
                "Zone > The Sceptre of God",
                "Zone > The Upper Sceptre of God – Kill Dominus",
                "Speak to Dialla",
                "Zone > The Aqueduct",
                "Zone > Highgate"
            },
            new string[]
            {
                "Speak to Kira",
                "Zone > The Dried Lake – Kill Voll – Pick up Deshret’s Banner",
                "Logout",
                "Break Deshret’s Seal",
                "Zone > The Mines Level 1",
                "Zone > The Mines Level 2 – Click Deshret’s Spirit",
                "Zone > The Crystal Veins – Get waypoint",
                "Run Normal Lab",
                "Waypoint > Town",
                "Speak to Tasuni",
                "Waypoint > The Crystal Veins",
                "Zone > Daresso’s Dream – Kill Daresso – Pick up Eye of Daresso",
                "Portal > Town",
                "Waypoint > The Crystal Veins",
                "Zone > Kaom’s Dream – Kill Kaom – Pick up The Eye of Fury",
                "Portal > Town",
                "Waypoint > The Crystal Veins",
                "Speak to Dialla",
                "Zone > The Belly of the Beast Level 1",
                "Zone > The Belly of the Beast Level 2 – Kill Piety – Speak to Piety",
                "Zone > The Harvest – Get waypoint - Head East – Kill Maligaro/Doedre/Malachai (random spawn) - Pick up organ",
                "Portal > Town",
                "Waypoint > The Harvest - Head West - Kill remaining 2 of Maligaro/Doedre/Malachai - Pick up organs",
                "Portal > Town",
                "Waypoint > The Harvest – Speak to Piety",
                "Zone > The Black Core – Kill Malachai",
                "Portal > Town",
                "Speak to Dialla",
                "Zone > The Ascent",
                "Zone > The Slave Pens",
                "Zone > The Overseer’s Tower"
            },
            new string[]
            {
                "Speak to Lani",
                "Zone > The Control Blocks – Pick up The Miasmeter – Kill Justicar Casticus - Pick up Eyes of Zeal",
                "Zone > Oriath Square",
                "Zone > The Templar Courts",
                "Zone > The Chamber of Innocence (Good place to reset zone and grind levels) – Get waypoint",
                "Waypoint > Town",
                "Speak to Lani, Vilenta",
                "Waypoint > The Chamber of Innocence – Kill Innocence",
                "Zone > The Torched Courts",
                "Zone > The Ruined Square – Get waypoint",
                "Zone > The Ossuary – Pick up Sign of Purity",
                "Logout",
                "Waypoint > The Ruined Square – Place portal near The Cathedral Rooftop zone (north)",
                "Zone > The Reliquary – Pick up the 3 Kitava’s Torments",
                "Waypoint > Town",
                "Speak to Lani",
                "Take your Portal to The Ruined Square",
                "Zone > The Cathedral Rooftop",
                "Zone > The Cathedral Apex – Kill Kitava (Check your resists first)",
                "Zone > The Cathedral Rooftop",
                "Speak to Lilly > Sail to Wraeclast"
            },
            new string[]
            {
                "Try to have at least capped fire resistance",
                "Zone > The Coast – Get Waypoint",
                "Zone > The Mud Flats – Kill The Dishonoured Queen – Pick up The Eye of Conquest",
                "Zone > The Karui Fortress",
                "Zone > Tukohama’s Keep – Kill Tukohama",
                "Zone > The Karui Fortress",
                "Zone > The Ridge – Get waypoint",
                "Waypoint > The Coast",
                "Zone > The Tidal Island – Open Storage Chest – Pick up Bestel’s Manuscript",
                "Portal > Town",
                "Zone > The Twilight Strand – Speak to Einhar – Clear zone",
                "Logout",
                "Speak to Lily, Bestel, Tarkleigh",
                "Waypoint > The Ridge",
                "Zone > The Lower Prison – Get waypoint – Drop a portal near Shavronne’s Tower zone for Lab Trial if you haven’t run across it yet.",
                "Zone > Shavronne’s Tower",
                "Zone > Prison Rooftop – Kill Brutus and Shavronne",
                "Zone > The Warden’s Chambers (Grab crafting recipe)",
                "Zone > Prisoner’s Gate",
                "Waypoint > Town",
                "Take your Portal back to The Lower Prison – Lab Trial",
                "Logout",
                "Speak to Tarkleigh",
                "Waypoint > Prisoner’s Gate",
                "Zone > The Western Forest – Get waypoint",
                "Zone > The Riverways – Get waypoint",
                "Zone > The Southern Forest – Get waypoint",
                "Zone > The Cavern of Anger – Open Flag Chest and pick up The Black Flag",
                "Zone > The Beacon – Get waypoint – Activate the beacon – Speak to Weylam",
                "Zone > The Brine King’s Reef – Get waypoint – Kill the Brine King – Speak to Weylam",
                "Select Pantheons if you haven’t already"
            },
            new string[]
            {
                "Zone > The Broken Bridge – Find Silver Locket",
                "Zone > The Crossroads – Get waypoint - Head South",
                "Zone > The Fellshrine Ruins",
                "Zone > The Crypt – Lab Trial",
                "Zone > Stairs down – Pick up Maligaro’s Map",
                "Portal > Town",
                "Waypoint > The Crossroads - Head North",
                "Zone > The Chamber of Sins Level 1 – Get waypoint – Speak to Silk - Put Maligaro’s Map in the Map Device",
                "Zone > Maligaro’s Sanctum",
                "Zone > Maligaro’s Workshop – Kill Maligaro – Pick up Black Venom",
                "Portal > The Chamber of Sins Level 1 – Speak to Silk - Take Obsidian Key - Head through the path directly behind Silk",
                "Zone > The Chamber of Sins Level 2 – Lab Trial",
                "Zone > The Den",
                "Zone > The Ashen Fields - Follow the path West",
                "Zone > The Forest Encampment > Kill Gruest",
                "Zone > The Northern Forest – Drop a Portal at The Dread Thicket if you find it",
                "Zone > The Causeway – Get waypoint – Speak to Alva if you see her to get her in your HO",
                "Zone > The Vaal City – Curse the game for not getting the single possible good layout - Get waypoint – Speak to Yeena",
                "Waypoint > Town",
                "Speak to Helena, Yeena",
                "Take your Portal back to The Northern Forest (or WP to it if you didn’t find The Dread Thicket)",
                "Zone > The Dread Thicket – Pick up fireflies",
                "Zone > The Den of Despair – Kill Gruthkul",
                "Zone > The Dread Thicket (If you still need fireflies)",
                "Portal > Town",
                "Speak to Eramir, Weylam (Grab Granite flask)",
                "Waypoint > Act 6 – The Riverways - Head North",
                "Zone > The Wetlands",
                "Zone > The Spawning Ground – Kill Ryslatha, the Puppet Mistress",
                "Portal > Town",
                "Waypoint > Act 6 - Prisoner’s Gate",
                "Zone > Valley of the Firedrinker – Kill Abberath",
                "Logout",
                "Speak to Bestel, Tarkleigh",
                "Run Cruel Lab",
                "Waypoint > The Vaal City – Speak to Yeena",
                "Zone > The Temple of Decay Level 1",
                "Zone > The Temple of Decay Level 2",
                "Zone > Arakaali’s Web – Kill Arakaali",
                "Zone > The Sarn Ramparts",
                "Zone > The Sarn Encampment"
            },
            new string[]
            {
                "Zone > The Toxic Conduits",
                "Zone > Doedre’s Cesspool",
                "Zone > The Cauldron – Kill Doedre",
                "Zone > Sewer Outlet - Head East",
                "Zone > The Quay – Follow Southwest wall - Open Sealed Casket - Pick up Ankh of Eternity – Place a Portal at the path to the Resurrection Site",
                "Zone > The Grain Gate – Get waypoint (Follow entrances with corpses outside them) – Kill Gemling Legionnaires",
                "Zone > The Imperial Fields",
                "Zone > The Solaris Temple Level 1 – Get waypoint",
                "Waypoint > Town",
                "Take your Portal to The Quay",
                "Zone > Resurrection Site – Kill Tolman – Pick up amulet",
                "Logout",
                "Speak to Clarissa, Hargan, Maramoa",
                "Waypoint > The Solaris Temple Level 1",
                "Zone > The Solaris Temple Level 2 – Kill Dawn – Pick up Sun Orb",
                "Logout",
                "Waypoint > The Solaris Temple Level 1",
                "Zone > The Solaris Concourse",
                "Zone > The Harbour Bridge",
                "Zone > The Lunaris Concourse – Get waypoint",
                "Zone > The Lunaris Temple Level 1 – Get waypoint",
                "Zone > The Lunaris Temple Level 2 – Kill Dusk – Pick up Moon Orb",
                "Logout",
                "Waypoint > The Lunaris Concourse - Head South",
                "Zone > The Harbour Bridge",
                "Zone > The Sky Shrine – Click Statue of the Sisters - Kill Solaris and Lunaris",
                "Zone > The Blood Aqueduct (farm for levels and gear until at least 62, work on resistances)",
                "Zone > Highgate"
            },
            new string[]
            {
                "Waypoint > Act 8 - The Lunaris Concourse - Head West",
                "Zone > The Bath House – Kill Hector Titucius – Pick up The Wings of Vastiri – Lab Trial",
                "Zone > The High Gardens",
                "Zone > The Pools of Terror – Kill Yugul",
                "Portal > Town",
                "Speak to Hargan",
                "Waypoint > Act 9 Town",
                "Zone > The Descent",
                "Zone > The Vastiri Desert – Do Betrayal mission to get Jun in HO – Find Storm Blade",
                "Portal > Town",
                "Speak to Petarus and Vanja, Jun, Sin, Petarus and Vanja again to get the Bottled Storm",
                "Take your Portal back to The Vastiri Desert - Head East",
                "Zone > The Oasis",
                "Zone > The Sand Pit - Kill Shakari",
                "Portal > Town",
                "Waypoint > The Vastiri Desert - Head North",
                "Zone > The Foothills – Get waypoint - Head East",
                "Zone > The Boiling Lake – Kill The Basilisk – Pick up Basilisk Acid",
                "Portal > Town",
                "Waypoint > The Foothills - Head North",
                "Zone > The Tunnel – Lab Trial – Get waypoint",
                "Zone > The Quarry – Get waypoint – Speak to Sin - Head East (usually, sometimes North)",
                "Zone > The Refinery – Kill General Adus – Pick up Trarthan Powder",
                "Portal > Town",
                "Waypoint > The Quarry - Head West (usually, sometimes East)",
                "Zone > Shrine of Winds – Kill Garukhan – Pick up Sekhema Feather",
                "Portal > Town",
                "Speak to Irasha",
                "Waypoint > The Quarry – Speak to Sin",
                "Zone > The Belly of the Beast",
                "Zone > The Rotting Core",
                "Zone > The Black Core – Speak to Sin – Go through the 3 portals and kill Shavronne, Maligaro and Doedre – Speak to Sin when done",
                "Zone > The Black Heart – Kill The Depraved Trinity",
                "Portal > Town",
                "Waypoint > Act 10 Town"
            },
            new string[]
            {
                "Zone > The Cathedral Rooftop",
                "Zone > Cathedral Apex – Save Bannon",
                "Zone > The Cathedral Rooftop - Head South",
                "Zone > The Ravaged Square – Drop a Portal in the open area - Head East – Get waypoint",
                "Waypoint > Town",
                "Take your Portal back to The Ravaged Square - Head West",
                "Zone > The Control Blocks – Get waypoint",
                "Waypoint > The Ravaged Square",
                "Zone > The Ossuary – Pick up The Elixir of Allure - Lab Trial",
                "Logout",
                "Speak to Weylam, Bannon, Lani",
                "Run Merciless Lab",
                "Waypoint > The Control Blocks – Kill Vilenta",
                "Portal > Town",
                "Speak to Lani",
                "Waypoint > The Ravaged Square - Head Southeast",
                "Zone > The Torched Courts",
                "Zone > The Desecrated Chambers – Get waypoint",
                "Zone > Sanctum of Innocence – Kill Avarius – Pick up The Staff of Purity",
                "Portal > Town",
                "Speak to Bannon, Lani, Lilly",
                "Waypoint > The Ravaged Square – Head Southeast and speak to Innocence",
                "Zone > The Canals",
                "Zone > The Feeding Through – Speak to Sin",
                "Zone > Altar of Hunger – Kill Kitava - Speak to Sin - Take portal to Oriath - Speak to Lani to get your skill points"
            },
        };

        // Save file path
        string saveFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PoELevelingGuideSave");

        int nbact, nbquest;
        public Form1()
        {
            InitializeComponent();
        }

        // Button exit application
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Transparent background
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            blackSquare.BackColor = Color.FromArgb(28, 28, 28);

            // Combobox initialisation
            for(int x = 1; x <= 10; x++)
            {
                cbbAct.Items.Add("Act: " + x);
            }

            Object sauvegarde = Serialise.Recup(saveFile);
            if(sauvegarde != null)
            {
                nbact = ((Profile)sauvegarde).getAct();
                nbquest = ((Profile)sauvegarde).getQuest();

                cbbAct.SelectedIndex = nbact;
                txtQuest.Text = act[nbact][nbquest].ToString();

                int num = act[nbact].Length;
                if (nbquest == num - 1)
                {
                    btnNext.Enabled = false;
                }
                if(nbquest == 0)
                {
                    btnBack.Enabled = false;
                }
            }
            else
            {
                nbact = 0;
                nbquest = 0;
                cbbAct.SelectedIndex = nbact;
                txtQuest.Text = act[nbact][nbquest].ToString();
                btnBack.Enabled = false;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        // Previous quest
        private void btnBack_Click(object sender, EventArgs e)
        {
            nbquest -= 1;
            if(nbquest == 0)
            {
                btnBack.Enabled = false;
            }
            else if(nbquest > 0)
            {
                btnBack.Enabled = true;
                btnNext.Enabled = true;
            }
            questLoading();
        }

        // Next quest
        private void btnNext_Click(object sender, EventArgs e)
        {
            int num = act[nbact].Length;
            nbquest += 1;
            if(nbquest == num-1)
            {
                btnNext.Enabled = false;
            }
            else if(nbquest < num -1)
            {
                btnNext.Enabled = true;
                btnBack.Enabled = true;
            }
            questLoading();
        }


        // Display quest in txt area
        private void questLoading()
        {
            txtQuest.Text = act[nbact][nbquest].ToString();
        }

        // Act changing
        private void cbbAct_SelectionChangeCommitted(object sender, EventArgs e)
        {
            nbact = cbbAct.SelectedIndex;
            txtQuest.Text = act[nbact][0].ToString();

            nbquest = 0;
            btnBack.Enabled = false;
            btnNext.Enabled = true;
        }

        private void btnNext_KeyDown(object sender, KeyEventArgs e)
        {

        }

        // Save act and quest number
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Profile profile = new Profile(nbact, nbquest);
            Serialise.Sauve(saveFile, profile);
        }


    }
}

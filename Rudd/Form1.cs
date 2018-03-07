using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Rudd
{
    public partial class Rudd : Form
    {
        private Double dHDSubtotal, dSubtotal,dSubtotal1000, dTotal, dMarkUp, dLoadCellSubTotal, dSundriesTotal, dFlatBarMSTotal;
        private Parts pLoadPlate, pFootPlate, pCellHousing, pLoadBar, pCableCover, pBrackets, pLoadPlateSecu, pFootPlateSecu, pStickers1000,
                      pSingleLoadCell, pCable100A, pSpring, pAmphenolPlugs, pAmphenolCaps, pFeetBar, pPetrol, pElecGlovGog, pStickers, pHDStickers, pLabour,
                      pBraces, pBraces1000, pLoadcell, pPotting, pCable, pCutting, pFeet, pScrews, pHDScrews, pWeildingGas, pWeildingWire, pGalvanising = null;
        private FlatBar pFlatA, pFlatB, pFlatC, pFlatD = null;
        private Sundries pCuttingDiscs, pSanding, pDrill, pTap, pGlue, pPottingBox, pWireLead, pTapmatic = null;



        public Rudd()
        {
            InitializeComponent();
            cbxLoadCellKit.SelectedIndex = 0;

        }

        private void Rudd_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;

            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.label27, "R1169,53/btl (bottle hire) 30 Sets per Bottle");
            toolTip1.SetToolTip(this.label25, "8mm migwire");

            try
            {
                rtbNotes.LoadFile(@"RuddNotes.rtf");
            }
            catch (System.IO.FileNotFoundException fnfe)
            {

            }
        }


        private void tbBraces_Leave_1(object sender, EventArgs e)
        {
            removeR(tbBraces);
            
            try
            {
                if (pBraces == null)
                {
                    pBraces = new Parts(tbBracesQty.Text, tbBraces.Text, "brace");
                    populateFields(pBraces, tbBracesQty.Text, tbBraces.Text, "brace", tbBraces, tbBracesUnitCost, tbBracesSetCost);
                    addSubtotal(pBraces.getSetPrice());
                }
                else
                {
                    subtractSubTotal(pBraces.getSetPrice());
                    pBraces.setPrice(tbBraces.Text);
                    populateFields(pBraces, tbBracesQty.Text, tbBraces.Text, "brace", tbBraces, tbBracesUnitCost, tbBracesSetCost);
                    addSubtotal(pBraces.getSetPrice());
                }

            }
            catch (FormatException)
            {
                tbBraces.Text = "";
                tbBracesUnitCost.Text = "";
                tbBracesSetCost.Text = "";
                tbBraces.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbBraces1000_Leave(object sender, EventArgs e)
        {
            removeR(tbBraces1000);

            try
            {
                if (pBraces1000 == null)
                {
                    pBraces1000 = new Parts(tbBraces1000Qty.Text, tbBraces1000.Text, "brace1000");
                    populateFields(pBraces1000, tbBraces1000Qty.Text, tbBraces1000.Text, "brace1000", tbBraces1000, tbBraces1000UnitCost, tbBraces1000SetCost);
                    addSubtotal1000(pBraces1000.getSetPrice());
                }
                else
                {
                    subtractSubTotal1000(pBraces1000.getSetPrice());
                    pBraces1000.setPrice(tbBraces1000.Text);
                    populateFields(pBraces1000, tbBraces1000Qty.Text, tbBraces1000.Text, "brace1000", tbBraces1000, tbBraces1000UnitCost, tbBraces1000SetCost);
                    addSubtotal1000(pBraces1000.getSetPrice());
                }

            }
            catch (FormatException)
            {
                tbBraces1000.Text = "";
                tbBraces1000UnitCost.Text = "";
                tbBraces1000SetCost.Text = "";
                tbBraces1000.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbFeetBar_Leave(object sender, EventArgs e)
        {
            removeR(tbFeetBar);

            try
            {
                if (pFeetBar == null)
                {
                    pFeetBar = new Parts(tbFeetBarQty.Text, tbFeetBar.Text, "feetbar");
                    populateFields(pFeetBar, tbFeetBarQty.Text, tbFeetBar.Text, "feetbar", tbFeetBar, tbFeetBarUnitCost, tbFeetBarSetCost);
                    addSubtotal(pFeetBar.getSetPrice());
                    addSubtotal1000(pFeetBar.getSetPrice());
                }
                else
                {
                    subtractSubTotal(pFeetBar.getSetPrice());
                    subtractSubTotal1000(pFeetBar.getSetPrice());
                    pFeetBar.setPrice(tbFeetBar.Text);
                    populateFields(pFeetBar, tbFeetBarQty.Text, tbFeetBar.Text, "feetbar", tbFeetBar, tbFeetBarUnitCost, tbFeetBarSetCost);
                    addSubtotal(pFeetBar.getSetPrice());
                    addSubtotal1000(pFeetBar.getSetPrice());
                }
                
            }
            catch (FormatException)
            {
                tbFeetBar.Text = "";
                tbFeetBarUnitCost.Text = "";
                tbFeetBarSetCost.Text = "";
                tbFeetBar.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbLoadcell_Leave(object sender, EventArgs e)
        {
            removeR(tbLoadcell);

            try
            {
                
                if (pLoadcell == null)
                {
                    pLoadcell = new Parts(tbLoadcellQty.Text, tbLoadcell.Text, "loadcell");
                    populateFields(pLoadcell, tbLoadcellQty.Text, tbLoadcell.Text, "loadcell", tbLoadcell, tbLoadcellUnitCost, tbLoadcellSetCost);
                    addSubtotal(pLoadcell.getSetPrice());
                    addSubtotal1000(pLoadcell.getSetPrice());
                }
                else
                {
                    subtractSubTotal(pLoadcell.getSetPrice());
                    subtractSubTotal1000(pLoadcell.getSetPrice());
                    pLoadcell.setPrice(tbLoadcell.Text);
                    populateFields(pLoadcell, tbLoadcellQty.Text, tbLoadcell.Text, "loadcell", tbLoadcell, tbLoadcellUnitCost, tbLoadcellSetCost);
                    addSubtotal(pLoadcell.getSetPrice());
                    addSubtotal1000(pLoadcell.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbLoadcell.Text = "";
                tbLoadcellUnitCost.Text = "";
                tbLoadcellSetCost.Text = "";
                tbLoadcell.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void tbPotting_Leave(object sender, EventArgs e)
        {
            removeR(tbPotting);

            try
            {
                if (pPotting == null)
                {
                    pPotting = new Parts(tbPottingQty.Text, tbPotting.Text, "potting");
                    populateFields(pPotting, tbPottingQty.Text, tbPotting.Text, "potting", tbPotting, tbPottingUnitCost, tbPottingSetCost);
                    addSubtotal(pPotting.getSetPrice());
                    addSubtotal1000(pPotting.getSetPrice());
                }
                else
                {
                    subtractSubTotal(pPotting.getSetPrice());
                    subtractSubTotal1000(pPotting.getSetPrice());
                    pPotting.setPrice(tbPotting.Text);
                    populateFields(pPotting, tbPottingQty.Text, tbPotting.Text, "potting", tbPotting, tbPottingUnitCost, tbPottingSetCost);
                    addSubtotal(pPotting.getSetPrice());
                    addSubtotal1000(pPotting.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbPotting.Text = "";
                tbPottingUnitCost.Text = "";
                tbPottingSetCost.Text = "";
                tbPotting.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void tbCable_Leave(object sender, EventArgs e)
        {
            removeR(tbCable);

            try
            {
                if (pCable == null)
                {
                    pCable = new Parts(tbCableQty.Text, tbCable.Text, "cable");
                    populateFields(pCable, tbCableQty.Text, tbCable.Text, "cable", tbCable, tbCableUnitCost, tbCableSetCost);
                    addSubtotal(pCable.getSetPrice());
                    addSubtotal1000(pCable.getSetPrice());
                }
                else
                {
                    subtractSubTotal(pCable.getSetPrice());
                    subtractSubTotal1000(pCable.getSetPrice());
                    pCable.setPrice(tbCable.Text);
                    populateFields(pCable, tbCableQty.Text, tbCable.Text, "cable", tbCable, tbCableUnitCost, tbCableSetCost);
                    addSubtotal(pCable.getSetPrice());
                    addSubtotal1000(pCable.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbCable.Text = "";
                tbCableUnitCost.Text = "";
                tbCableSetCost.Text = "";
                tbCable.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            removeR(tbCutting);

            try
            {
                if (pCutting == null)
                {
                    pCutting = new Parts("1", tbCutting.Text, "single");
                    populateFields(pCutting, "1", tbCutting.Text, "single", tbCutting, tbCuttingCost, tbCuttingCost);
                    addSubtotal(pCutting.getSetPrice());
                    addSubtotal1000(pCutting.getSetPrice());
                }
                else
                {
                    subtractSubTotal(pCutting.getSetPrice());
                    subtractSubTotal1000(pCutting.getSetPrice());
                    pCutting.setPrice(tbCutting.Text);
                    populateFields(pCutting, "1", tbCutting.Text, "single", tbCutting, tbCuttingCost, tbCuttingCost);
                    addSubtotal(pCutting.getSetPrice());
                    addSubtotal1000(pCutting.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbCutting.Text = "";
                tbCuttingCost.Text = "";
                tbCutting.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbFeet_Leave(object sender, EventArgs e)
        {
            removeR(tbFeet);

            try
            {
                if (pFeet == null)
                {
                    pFeet = new Parts("1", tbFeet.Text, "single");
                    populateFields(pFeet, "1", tbFeet.Text, "single", tbFeet, tbFeetCost, tbFeetCost);
                    addSubtotal(pFeet.getSetPrice());
                    addSubtotal1000(pFeet.getSetPrice());
                }
                else
                {
                    subtractSubTotal(pFeet.getSetPrice());
                    subtractSubTotal1000(pFeet.getSetPrice());
                    pFeet.setPrice(tbFeet.Text);
                    populateFields(pFeet, "1", tbFeet.Text, "single", tbFeet, tbFeetCost, tbFeetCost);
                    addSubtotal(pFeet.getSetPrice());
                    addSubtotal1000(pFeet.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbFeet.Text = "";
                tbFeetCost.Text = "";
                tbFeet.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void tbScrews_Leave(object sender, EventArgs e)
        {
            removeR(tbScrews);

            try
            {
                if (pScrews == null)
                {
                    pScrews = new Parts(tbScrewsQty.Text, tbScrews.Text, "single");
                    populateFields(pScrews, tbScrewsQty.Text, tbScrews.Text, "single", tbScrews, tbScrewsCost, tbScrewsCost);
                    addSubtotal(pScrews.getSetPrice());
                    addSubtotal1000(pScrews.getSetPrice());
                }
                else
                {
                    subtractSubTotal(pScrews.getSetPrice());
                    subtractSubTotal1000(pScrews.getSetPrice());
                    pScrews.setPrice(tbScrews.Text);
                    populateFields(pScrews, tbScrewsQty.Text, tbScrews.Text, "single", tbScrews, tbScrewsCost, tbScrewsCost);
                    addSubtotal(pScrews.getSetPrice());
                    addSubtotal1000(pScrews.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbScrews.Text = "";
                tbScrewsCost.Text = "";
                tbScrews.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void tbHDScrews_Leave(object sender, EventArgs e)
        {
            removeR(tbHDScrews);

            try
            {
                if (pHDScrews == null)
                {
                    pHDScrews = new Parts(tbHDScrewsQty.Text, tbHDScrews.Text, "single");
                    populateFields(pHDScrews, tbHDScrewsQty.Text, tbHDScrews.Text, "single", tbHDScrews, tbHDScrewsCost, tbHDScrewsCost);
                    addHDSubtotal(pHDScrews.getSetPrice());
                }
                else
                {
                    subtractHDSubTotal(pHDScrews.getSetPrice());
                    pHDScrews.setPrice(tbHDScrews.Text);
                    populateFields(pHDScrews, tbHDScrewsQty.Text, tbHDScrews.Text, "single", tbHDScrews, tbHDScrewsCost, tbHDScrewsCost);
                    addHDSubtotal(pHDScrews.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbHDScrews.Text = "";
                tbHDScrewsCost.Text = "";
                tbHDScrews.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbWeildingGas_Leave(object sender, EventArgs e)
        {
            removeR(tbWeildingGas);

            try
            {
                if (pWeildingGas == null)
                {
                    pWeildingGas = new Parts("1", tbWeildingGas.Text, "gas");
                    populateFields(pWeildingGas, "1", tbWeildingGas.Text, "gas", tbWeildingGas, tbWeildingGasCost, tbWeildingGasCost);
                    addSubtotal(pWeildingGas.getSetPrice());
                    addSubtotal1000(pWeildingGas.getSetPrice());
                    addHDSubtotal(pWeildingGas.getSetPrice());
                }
                else
                {
                    subtractHDSubTotal(pWeildingGas.getSetPrice());
                    subtractSubTotal(pWeildingGas.getSetPrice());
                    subtractSubTotal1000(pWeildingGas.getSetPrice());
                    pWeildingGas.setPrice(tbWeildingGas.Text);
                    populateFields(pWeildingGas, "1", tbWeildingGas.Text, "gas", tbWeildingGas, tbWeildingGasCost, tbWeildingGasCost);
                    addSubtotal(pWeildingGas.getSetPrice());
                    addSubtotal1000(pWeildingGas.getSetPrice());
                    addHDSubtotal(pWeildingGas.getSetPrice());
                }
            }

            catch (FormatException)
            {
                tbWeildingGas.Text = "";
                tbWeildingGasCost.Text = "";
                tbWeildingGas.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void tbWeildingWire_Leave(object sender, EventArgs e)
        {
            removeR(tbWeildingWire);

            try
            {
                if (pWeildingWire == null)
                {
                    pWeildingWire = new Parts("1", tbWeildingWire.Text, "wire");
                    populateFields(pWeildingWire, "1", tbWeildingWire.Text, "wire", tbWeildingWire, tbWeildingWireCost, tbWeildingWireCost);
                    addSubtotal(pWeildingWire.getSetPrice());
                    addSubtotal1000(pWeildingWire.getSetPrice());
                    addHDSubtotal(pWeildingWire.getSetPrice());
                }
                else
                {
                    subtractSubTotal(pWeildingWire.getSetPrice());
                    subtractSubTotal1000(pWeildingWire.getSetPrice());
                    subtractHDSubTotal(pWeildingWire.getSetPrice());
                    pWeildingWire.setPrice(tbWeildingWire.Text);
                    populateFields(pWeildingWire, "1", tbWeildingWire.Text, "wire", tbWeildingWire, tbWeildingWireCost, tbWeildingWireCost);
                    addSubtotal(pWeildingWire.getSetPrice());
                    addSubtotal1000(pWeildingWire.getSetPrice());
                    addHDSubtotal(pWeildingWire.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbWeildingWire.Text = "";
                tbWeildingWireCost.Text = "";
                tbWeildingWire.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void tbGalvanising_Leave(object sender, EventArgs e)
        {
            removeR(tbGalvanising);

            try
            {
                if (pGalvanising == null)
                {
                    pGalvanising = new Parts("1", tbGalvanising.Text, "galvanising");
                    populateFields(pGalvanising, "1", tbGalvanising.Text, "galvanising", tbGalvanising, tbGalvanisingCost, tbGalvanisingCost);
                    addSubtotal(pGalvanising.getSetPrice());
                    addSubtotal1000(pGalvanising.getSetPrice());
                    addHDSubtotal(pGalvanising.getSetPrice());
                }
                else
                {
                    subtractSubTotal(pGalvanising.getSetPrice());
                    subtractSubTotal1000(pGalvanising.getSetPrice());
                    subtractHDSubTotal(pGalvanising.getSetPrice());
                    pGalvanising.setPrice(tbGalvanising.Text);
                    populateFields(pGalvanising, "1", tbGalvanising.Text, "galvanising", tbGalvanising, tbGalvanisingCost, tbGalvanisingCost);
                    addSubtotal(pGalvanising.getSetPrice());
                    addSubtotal1000(pGalvanising.getSetPrice());
                    addHDSubtotal(pGalvanising.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbGalvanising.Text = "";
                tbGalvanisingCost.Text = "";
                tbGalvanising.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbPetrol_Leave(object sender, EventArgs e)
        {
            removeR(tbPetrol);

            try
            {
                if (pPetrol == null)
                {
                    pPetrol = new Parts("1", tbPetrol.Text, "petrol");
                    populateFields(pPetrol, "1", tbPetrol.Text, "petrol", tbPetrol, tbPetrolCost, tbPetrolCost);
                    tbPetrolCost.Text = setText(pPetrol.getFuelPrice().ToString());
                    addSubtotal(pPetrol.getSetPrice());
                    addSubtotal1000(pPetrol.getSetPrice());
                    addHDSubtotal(pPetrol.getSetPrice());
                }
                else
                {
                    subtractSubTotal(pPetrol.getSetPrice());
                    subtractSubTotal1000(pPetrol.getSetPrice());
                    subtractHDSubTotal(pPetrol.getSetPrice());
                    populateFields(pPetrol, "1", tbPetrol.Text, "petrol", tbPetrol, tbPetrolCost, tbPetrolCost);
                    tbPetrolCost.Text = setText(pPetrol.getFuelPrice().ToString());
                    addSubtotal(pPetrol.getSetPrice());
                    addSubtotal1000(pPetrol.getSetPrice());
                    addHDSubtotal(pPetrol.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbPetrol.Text = "";
                tbPetrolCost.Text = "";
                tbPetrol.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbElecGlovGog_Leave(object sender, EventArgs e)
        {
            removeR(tbElecGlovGog);

            try
            {
                if (pElecGlovGog == null)
                {
                    pElecGlovGog = new Parts("1", tbElecGlovGog.Text, "single");
                    populateFields(pElecGlovGog, "1", tbElecGlovGog.Text, "single", tbElecGlovGog, tbElecGlovGogCost, tbElecGlovGogCost);
                    addSubtotal(pElecGlovGog.getSetPrice());
                    addSubtotal1000(pElecGlovGog.getSetPrice());
                    addHDSubtotal(pElecGlovGog.getSetPrice());
                }
                else
                {
                    subtractSubTotal(pElecGlovGog.getSetPrice());
                    subtractSubTotal1000(pElecGlovGog.getSetPrice());
                    subtractHDSubTotal(pElecGlovGog.getSetPrice());
                    pElecGlovGog.setPrice(tbElecGlovGog.Text);
                    populateFields(pElecGlovGog, "1", tbElecGlovGog.Text, "single", tbElecGlovGog, tbElecGlovGogCost, tbElecGlovGogCost);
                    addSubtotal(pElecGlovGog.getSetPrice());
                    addSubtotal1000(pElecGlovGog.getSetPrice());
                    addHDSubtotal(pElecGlovGog.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbElecGlovGog.Text = "";
                tbElecGlovGogCost.Text = "";
                tbElecGlovGog.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbStickers_Leave(object sender, EventArgs e)
        {
            removeR(tbStickers);

            try
            {
                if (pStickers == null)
                {
                    pStickers = new Parts(tbStickersQty.Text, tbStickers.Text, "single");
                    populateFields(pStickers, tbStickersQty.Text, tbStickers.Text, "single", tbStickers, tbStickersCost, tbStickersCost);
                    addSubtotal(pStickers.getSetPrice());
                }
                else
                {
                    subtractSubTotal(pStickers.getSetPrice());
                    pStickers.setPrice(tbStickers.Text);
                    populateFields(pStickers, tbStickersQty.Text, tbStickers.Text, "single", tbStickers, tbStickersCost, tbStickersCost);
                    addSubtotal(pStickers.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbStickers.Text = "";
                tbStickersCost.Text = "";
                tbStickers.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbStickers1000_Leave(object sender, EventArgs e)
        {
            removeR(tbStickers1000);

            try
            {
                if (pStickers1000 == null)
                {
                    pStickers1000 = new Parts(tbStickers1000Qty.Text, tbStickers1000.Text, "single");
                    populateFields(pStickers1000, tbStickers1000Qty.Text, tbStickers1000.Text, "single", tbStickers1000, tbStickers1000Cost, tbStickers1000Cost);
                    addSubtotal1000(pStickers1000.getSetPrice());
                }
                else
                {
                    subtractSubTotal1000(pStickers1000.getSetPrice());
                    pStickers1000.setPrice(tbStickers1000.Text);
                    populateFields(pStickers1000, tbStickers1000Qty.Text, tbStickers1000.Text, "single", tbStickers1000, tbStickers1000Cost, tbStickers1000Cost);
                    addSubtotal1000(pStickers1000.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbStickers1000.Text = "";
                tbStickers1000Cost.Text = "";
                tbStickers1000.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbHDStickers_Leave(object sender, EventArgs e)
        {
            removeR(tbHDStickers);

            try
            {
                if (pHDStickers == null)
                {
                    pHDStickers = new Parts(tbHDStickersQty.Text, tbHDStickers.Text, "single");
                    populateFields(pHDStickers, tbHDStickersQty.Text, tbHDStickers.Text, "single", tbHDStickers, tbHDStickersCost, tbHDStickersCost);
                    addHDSubtotal(pHDStickers.getSetPrice());
                }
                else
                {
                    subtractHDSubTotal(pHDStickers.getSetPrice());
                    pHDStickers.setPrice(tbHDStickers.Text);
                    populateFields(pHDStickers, tbHDStickersQty.Text, tbHDStickers.Text, "single", tbHDStickers, tbHDStickersCost, tbHDStickersCost);
                    addHDSubtotal(pHDStickers.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbHDStickers.Text = "";
                tbHDStickersCost.Text = "";
                tbHDStickers.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void tbLabour_Leave(object sender, EventArgs e)
        {
            removeR(tbLabour);

            try
            {
                if (pLabour == null)
                {
                    pLabour = new Parts(tbLabourQty.Text, tbLabour.Text, "single");
                    populateFields(pLabour, tbLabourQty.Text, tbLabour.Text, "single", tbLabour, tbLabourCost, tbLabourCost);
                    addSubtotal(pLabour.getSetPrice());
                    addSubtotal1000(pLabour.getSetPrice());
                    addHDSubtotal(pLabour.getSetPrice());
                }
                else
                {
                    subtractSubTotal(pLabour.getSetPrice());
                    subtractSubTotal1000(pLabour.getSetPrice());
                    subtractHDSubTotal(pLabour.getSetPrice());
                    pLabour.setPrice(tbLabour.Text);
                    populateFields(pLabour, tbLabourQty.Text, tbLabour.Text, "single", tbLabour, tbLabourCost, tbLabourCost);
                    addSubtotal(pLabour.getSetPrice());
                    addSubtotal1000(pLabour.getSetPrice());
                    addHDSubtotal(pLabour.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbLabour.Text = "";
                tbLabourCost.Text = "";
                tbLabour.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbLoadPlate_Leave(object sender, EventArgs e)
        {
            removeR(tbLoadPlate);

            try
            {
                if (pLoadPlate == null)
                {
                    pLoadPlate = new Parts(tbLoadPlateQty.Text, tbLoadPlate.Text, "single");
                    populateFields(pLoadPlate, tbLabourQty.Text, tbLoadPlate.Text, "single", tbLoadPlate, tbLoadPlateCost, tbLoadPlateCost);
                    addHDSubtotal(pLoadPlate.getSetPrice());
                }
                else
                {
                    subtractHDSubTotal(pLoadPlate.getSetPrice());
                    pLoadPlate.setPrice(tbLoadPlate.Text);
                    populateFields(pLoadPlate, tbLabourQty.Text, tbLoadPlate.Text, "single", tbLoadPlate, tbLoadPlateCost, tbLoadPlateCost);
                    addHDSubtotal(pLoadPlate.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbLoadPlate.Text = "";
                tbLoadPlateCost.Text = "";
                tbLoadPlate.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbFootPlate_Leave(object sender, EventArgs e)
        {
            removeR(tbFootPlate);

            try
            {
                if (pFootPlate == null)
                {
                    pFootPlate = new Parts(tbFootPlateQty.Text, tbFootPlate.Text, "single");
                    populateFields(pFootPlate, tbFootPlateQty.Text, tbFootPlate.Text, "single", tbFootPlate, tbFootPlateCost, tbFootPlateCost);
                    addHDSubtotal(pFootPlate.getSetPrice());
                }
                else
                {
                    subtractHDSubTotal(pFootPlate.getSetPrice());
                    pFootPlate.setPrice(tbFootPlate.Text);
                    populateFields(pFootPlate, tbFootPlateQty.Text, tbFootPlate.Text, "single", tbFootPlate, tbFootPlateCost, tbFootPlateCost);
                    addHDSubtotal(pFootPlate.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbFootPlate.Text = "";
                tbFootPlateCost.Text = "";
                tbFootPlate.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbCellHousing_Leave(object sender, EventArgs e)
        {
            removeR(tbCellHousing);

            try
            {
                if (pCellHousing == null)
                {
                    pCellHousing = new Parts(tbCellHousingQty.Text, tbCellHousing.Text, "single");
                    populateFields(pCellHousing, tbCellHousingQty.Text, tbCellHousing.Text, "single", tbCellHousing, tbCellHousingCost, tbCellHousingCost);
                    addHDSubtotal(pCellHousing.getSetPrice());
                }
                else
                {
                    subtractHDSubTotal(pCellHousing.getSetPrice());
                    pCellHousing.setPrice(tbCellHousing.Text);
                    populateFields(pCellHousing, tbCellHousingQty.Text, tbCellHousing.Text, "single", tbCellHousing, tbCellHousingCost, tbCellHousingCost);
                    addHDSubtotal(pCellHousing.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbCellHousing.Text = "";
                tbCellHousingCost.Text = "";
                tbCellHousing.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbLoadBar_Leave(object sender, EventArgs e)
        {
            removeR(tbLoadBar);

            try
            {
                if (pLoadBar == null)
                {
                    pLoadBar = new Parts(tbLoadBarQty.Text, tbLoadBar.Text, "single");
                    populateFields(pLoadBar, tbLoadBarQty.Text, tbLoadBar.Text, "single", tbLoadBar, tbLoadBarCost, tbLoadBarCost);
                    addHDSubtotal(pLoadBar.getSetPrice());
                }
                else
                {
                    subtractHDSubTotal(pLoadBar.getSetPrice());
                    pLoadBar.setPrice(tbLoadBar.Text);
                    populateFields(pLoadBar, tbLoadBarQty.Text, tbLoadBar.Text, "single", tbLoadBar, tbLoadBarCost, tbLoadBarCost);
                    addHDSubtotal(pLoadBar.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbLoadBar.Text = "";
                tbLoadBarCost.Text = "";
                tbLoadBar.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbCableCover_Leave(object sender, EventArgs e)
        {
            removeR(tbCableCover);

            try
            {
                if (pCableCover == null)
                {
                    pCableCover = new Parts(tbCableCoverQty.Text, tbCableCover.Text, "single");
                    populateFields(pCableCover, tbCableCoverQty.Text, tbCableCover.Text, "single", tbCableCover, tbCableCoverCost, tbCableCoverCost);
                    addHDSubtotal(pCableCover.getSetPrice());
                }
                else
                {
                    subtractHDSubTotal(pCableCover.getSetPrice());
                    pCableCover.setPrice(tbCableCover.Text);
                    populateFields(pCableCover, tbCableCoverQty.Text, tbCableCover.Text, "single", tbCableCover, tbCableCoverCost, tbCableCoverCost);
                    addHDSubtotal(pCableCover.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbCableCover.Text = "";
                tbCableCoverCost.Text = "";
                tbCableCover.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbBrackets_Leave(object sender, EventArgs e)
        {
            removeR(tbBrackets);

            try
            {
                if (pBrackets == null)
                {
                    pBrackets = new Parts(tbBracketsQty.Text, tbBrackets.Text, "single");
                    populateFields(pBrackets, tbBracketsQty.Text, tbBrackets.Text, "single", tbBrackets, tbBracketsCost, tbBracketsCost);
                    addHDSubtotal(pBrackets.getSetPrice());
                }
                else
                {
                    subtractHDSubTotal(pBrackets.getSetPrice());
                    pBrackets.setPrice(tbBrackets.Text);
                    populateFields(pBrackets, tbBracketsQty.Text, tbBrackets.Text, "single", tbBrackets, tbBracketsCost, tbBracketsCost);
                    addHDSubtotal(pBrackets.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbBrackets.Text = "";
                tbBracketsCost.Text = "";
                tbBrackets.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbLoadPlateSecu_Leave(object sender, EventArgs e)
        {
            removeR(tbLoadPlateSecu);

            try
            {
                if (pLoadPlateSecu == null)
                {
                    pLoadPlateSecu = new Parts(tbLoadPlateSecuQty.Text, tbLoadPlateSecu.Text, "plateSecu");
                    populateFields(pLoadPlateSecu, tbLoadPlateSecuQty.Text, tbLoadPlateSecu.Text, "plateSecu", tbLoadPlateSecu, tbLoadPlateSecuUnitCost, tbLoadPlateSecuCost);
                    addHDSubtotal(pLoadPlateSecu.getSetPrice());
                }
                else
                {
                    subtractHDSubTotal(pLoadPlateSecu.getSetPrice());
                    pLoadPlateSecu.setPrice(tbLoadPlateSecu.Text);
                    populateFields(pLoadPlateSecu, tbLoadPlateSecuQty.Text, tbLoadPlateSecu.Text, "plateSecu", tbLoadPlateSecu, tbLoadPlateSecuUnitCost, tbLoadPlateSecuCost);
                    addHDSubtotal(pLoadPlateSecu.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbLoadPlateSecu.Text = "";
                tbLoadPlateSecuCost.Text = "";
                tbLoadPlateSecu.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbPottingQBooks_Leave(object sender, EventArgs e)
        {
            try
            {
                tbPottingQBooks.Text = setText(tbPottingQBooks.Text.Replace(".", ","));
            }
            catch (FormatException)
            {
                tbPottingQBooks.Text = "";
                tbPottingQBooks.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbFootPlateSecu_Leave(object sender, EventArgs e)
        {
            removeR(tbFootPlateSecu);

            try
            {
                if (pFootPlateSecu == null)
                {
                    pFootPlateSecu = new Parts(tbFootPlateSecuQty.Text, tbFootPlateSecu.Text, "plateSecu");
                    populateFields(pFootPlateSecu, tbFootPlateSecuQty.Text, tbFootPlateSecu.Text, "plateSecu", tbFootPlateSecu, tbFootPlateSecuUnitCost, tbFootPlateSecuCost);
                    addHDSubtotal(pFootPlateSecu.getSetPrice());
                }
                else
                {
                    subtractHDSubTotal(pFootPlateSecu.getSetPrice());
                    pFootPlateSecu.setPrice(tbFootPlateSecu.Text);
                    populateFields(pFootPlateSecu, tbFootPlateSecuQty.Text, tbFootPlateSecu.Text, "plateSecu", tbFootPlateSecu, tbFootPlateSecuUnitCost, tbFootPlateSecuCost);
                    addHDSubtotal(pFootPlateSecu.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbFootPlateSecu.Text = "";
                tbFootPlateSecuCost.Text = "";
                tbFootPlateSecu.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbSingleLoadCell_Leave(object sender, EventArgs e)
        {
            removeR(tbSingleLoadCell);

            try
            {
                if (pSingleLoadCell == null)
                {
                    pSingleLoadCell = new Parts(tbSingleLoadCellQty.Text, tbSingleLoadCell.Text, "single");
                    populateFields(pSingleLoadCell, tbSingleLoadCellQty.Text, tbSingleLoadCell.Text,
                                    "single", tbSingleLoadCell, tbSingleLoadCellUnitCost, tbSingleLoadCellCost);
                    addLoadCellKitTotal(pSingleLoadCell.getSetPrice());
                }
                else
                {
                    subtractLoadCellKitTotal(pSingleLoadCell.getSetPrice());
                    pSingleLoadCell.setPrice(tbSingleLoadCell.Text);
                    populateFields(pSingleLoadCell, tbSingleLoadCellQty.Text, tbSingleLoadCell.Text,
                                    "single", tbSingleLoadCell, tbSingleLoadCellUnitCost, tbSingleLoadCellCost);
                    addLoadCellKitTotal(pSingleLoadCell.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbSingleLoadCell.Text = "";
                tbSingleLoadCellUnitCost.Text = "";
                tbSingleLoadCellCost.Text = "";
                tbSingleLoadCell.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbCable100A_Leave(object sender, EventArgs e)
        {
            removeR(tbCable100A);

            try
            {
                if (pCable100A == null)
                {
                    pCable100A = new Parts(tbCable100AQty.Text, tbCable100A.Text, "single");
                    populateFields(pCable100A, tbCable100AQty.Text, tbCable100A.Text,
                                    "single", tbCable100A, tbCable100AUnitCost, tbCable100ACost);
                    addLoadCellKitTotal(pCable100A.getSetPrice());
                }
                else
                {
                    subtractLoadCellKitTotal(pCable100A.getSetPrice());
                    pCable100A.setPrice(tbCable100A.Text);
                    populateFields(pCable100A, tbCable100AQty.Text, tbCable100A.Text,
                                    "single", tbCable100A, tbCable100AUnitCost, tbCable100ACost);
                    addLoadCellKitTotal(pCable100A.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbCable100A.Text = "";
                tbCable100AUnitCost.Text = "";
                tbCable100ACost.Text = "";
                tbCable100A.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbSpring_Leave(object sender, EventArgs e)
        {
            removeR(tbSpring);

            try
            {
                if (pSpring == null)
                {
                    pSpring = new Parts(tbSpringQty.Text, tbSpring.Text, "single");
                    populateFields(pSpring, tbSpringQty.Text, tbSpring.Text,
                                    "single", tbSpring, tbSpringUnitCost, tbSpringCost);
                    addLoadCellKitTotal(pSpring.getSetPrice());
                }
                else
                {
                    subtractLoadCellKitTotal(pSpring.getSetPrice());
                    pSpring.setPrice(tbSpring.Text);
                    populateFields(pSpring, tbSpringQty.Text, tbSpring.Text,
                                    "single", tbSpring, tbSpringUnitCost, tbSpringCost);
                    addLoadCellKitTotal(pSpring.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbSpring.Text = "";
                tbSpringUnitCost.Text = "";
                tbSpringCost.Text = "";
                tbSpring.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbAmphenolPlugs_Leave(object sender, EventArgs e)
        {
            removeR(tbAmphenolPlugs);

            try
            {
                if (pAmphenolPlugs == null)
                {
                    pAmphenolPlugs = new Parts(tbAmphenolPlugsQty.Text, tbAmphenolPlugs.Text, "single");
                    populateFields(pAmphenolPlugs, tbAmphenolPlugsQty.Text, tbAmphenolPlugs.Text,
                                    "single", tbAmphenolPlugs, tbAmphenolPlugsUnitCost, tbAmphenolPlugsCost);
                    addLoadCellKitTotal(pAmphenolPlugs.getSetPrice());
                }
                else
                {
                    subtractLoadCellKitTotal(pAmphenolPlugs.getSetPrice());
                    pAmphenolPlugs.setPrice(tbAmphenolPlugs.Text);
                    populateFields(pAmphenolPlugs, tbAmphenolPlugsQty.Text, tbAmphenolPlugs.Text,
                                   "single", tbAmphenolPlugs, tbAmphenolPlugsUnitCost, tbAmphenolPlugsCost);
                    addLoadCellKitTotal(pAmphenolPlugs.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbAmphenolPlugs.Text = "";
                tbAmphenolPlugsUnitCost.Text = "";
                tbAmphenolPlugsCost.Text = "";
                tbAmphenolPlugs.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbAmphenolCaps_Leave(object sender, EventArgs e)
        {
            removeR(tbAmphenolCaps);

            try
            {
                if (pAmphenolCaps == null)
                {
                    pAmphenolCaps = new Parts(tbAmphenolCapsQty.Text, tbAmphenolCaps.Text, "single");
                    populateFields(pAmphenolCaps, tbAmphenolCapsQty.Text, tbAmphenolCaps.Text,
                                    "single", tbAmphenolCaps, tbAmphenolCapsUnitCost, tbAmphenolCapsCost);
                    addLoadCellKitTotal(pAmphenolCaps.getSetPrice());
                }
                else
                {
                    subtractLoadCellKitTotal(pAmphenolCaps.getSetPrice());
                    pAmphenolCaps.setPrice(tbAmphenolCaps.Text);
                    populateFields(pAmphenolCaps, tbAmphenolCapsQty.Text, tbAmphenolCaps.Text,
                                    "single", tbAmphenolCaps, tbAmphenolCapsUnitCost, tbAmphenolCapsCost);
                    addLoadCellKitTotal(pAmphenolCaps.getSetPrice());
                }
            }
            catch (FormatException)
            {
                tbAmphenolCaps.Text = "";
                tbAmphenolCapsUnitCost.Text = "";
                tbAmphenolCapsCost.Text = "";
                tbAmphenolCaps.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbCellQBooks_Leave(object sender, EventArgs e)
        {
            try
            {
                tbCellQBooks.Text = setText(tbCellQBooks.Text.Replace(".", ","));
            }
            catch (FormatException)
            {
                tbCellQBooks.Text = "";
                tbCellQBooks.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbCableQBooks_Leave(object sender, EventArgs e)
        {
            try
            {
                tbCableQBooks.Text = setText(tbCableQBooks.Text.Replace(".", ","));
            }
            catch (FormatException)
            {
                tbCableQBooks.Text = "";
                tbCableQBooks.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbSpringQBooks_Leave(object sender, EventArgs e)
        {
            try
            {
                tbSpringQBooks.Text = setText(tbSpringQBooks.Text.Replace(".", ","));
            }
            catch (FormatException)
            {
                tbSpringQBooks.Text = "";
                tbSpringQBooks.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbPlugsQBooks_Leave(object sender, EventArgs e)
        {
            try
            {
                tbPlugsQBooks.Text = setText(tbPlugsQBooks.Text.Replace(".", ","));
            }
            catch (FormatException)
            {
                tbPlugsQBooks.Text = "";
                tbPlugsQBooks.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbCapsQBooks_Leave(object sender, EventArgs e)
        {
            try
            {
                tbCapsQBooks.Text = setText(tbCapsQBooks.Text.Replace(".", ","));
            }
            catch (FormatException)
            {
                tbCapsQBooks.Text = "";
                tbCapsQBooks.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbFlatA_Leave(object sender, EventArgs e)
        {
            removeR(tbFlatA);

            try
            {
                if (pFlatA == null)
                {
                    pFlatA = new FlatBar(tbFlatA.Text, tbFlatAQty.Text, tbFlatAUnit.Text);
                    populateFlatBarFields(pFlatA, tbFlatA, tbFlatAMeter, tbFlatACost);
                    addFlatBarMSTotal(pFlatA.getCostperUnit());
                }
                else
                {
                    subtractFlatBarMSTotal(pFlatA.getCostperUnit());
                    pFlatA = new FlatBar(tbFlatA.Text, tbFlatAQty.Text, tbFlatAUnit.Text);
                    pFlatA.setPrice(tbFlatA.Text);
                    populateFlatBarFields(pFlatA, tbFlatA, tbFlatAMeter, tbFlatACost);
                    addFlatBarMSTotal(pFlatA.getCostperUnit());
                }
            }
            catch (FormatException)
            {
                tbFlatA.Text = "R0,00";
                tbFlatAMeter.Text = "";
                tbFlatACost.Text = "";
                tbFlatA.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbFlatB_Leave(object sender, EventArgs e)
        {
            removeR(tbFlatB);

            try
            {
                if (pFlatB == null)
                {
                    pFlatB = new FlatBar(tbFlatB.Text, tbFlatBQty.Text, tbFlatBUnit.Text);
                    populateFlatBarFields(pFlatB, tbFlatB, tbFlatBMeter, tbFlatBCost);
                    addFlatBarMSTotal(pFlatB.getCostperUnit());
                }
                else
                {
                    subtractFlatBarMSTotal(pFlatB.getCostperUnit());
                    pFlatB = new FlatBar(tbFlatB.Text, tbFlatBQty.Text, tbFlatBUnit.Text);
                    pFlatB.setPrice(tbFlatB.Text);
                    populateFlatBarFields(pFlatB, tbFlatB, tbFlatBMeter, tbFlatBCost);
                    addFlatBarMSTotal(pFlatB.getCostperUnit());
                }
            }
            catch (FormatException)
            {
                tbFlatB.Text = "R0,00";
                tbFlatBMeter.Text = "";
                tbFlatBCost.Text = "";
                tbFlatB.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbFlatC_Leave(object sender, EventArgs e)
        {
            removeR(tbFlatC);

            try
            {
                if (pFlatC == null)
                {
                    pFlatC = new FlatBar(tbFlatC.Text, tbFlatCQty.Text, tbFlatCUnit.Text);
                    populateFlatBarFields(pFlatC, tbFlatC, tbFlatCMeter, tbFlatCCost);
                    addFlatBarMSTotal(pFlatC.getCostperUnit());
                }
                else
                {
                    subtractFlatBarMSTotal(pFlatC.getCostperUnit());
                    pFlatC = new FlatBar(tbFlatC.Text, tbFlatCQty.Text, tbFlatCUnit.Text);
                    pFlatC.setPrice(tbFlatC.Text);
                    populateFlatBarFields(pFlatC, tbFlatC, tbFlatCMeter, tbFlatCCost);
                    addFlatBarMSTotal(pFlatC.getCostperUnit());
                }
            }
            catch (FormatException)
            {
                tbFlatC.Text = "R0,00";
                tbFlatCMeter.Text = "";
                tbFlatCCost.Text = "";
                tbFlatC.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbFlatD_Leave(object sender, EventArgs e)
        {
            removeR(tbFlatD);

            try
            {
                if (pFlatD == null)
                {
                    pFlatD = new FlatBar(tbFlatD.Text, tbFlatDQty.Text, tbFlatDUnit.Text);
                    populateFlatBarFields(pFlatD, tbFlatD, tbFlatDMeter, tbFlatDCost);
                    addFlatBarMSTotal(pFlatD.getCostperUnit());
                }
                else
                {
                    subtractFlatBarMSTotal(pFlatD.getCostperUnit());
                    pFlatD = new FlatBar(tbFlatD.Text, tbFlatDQty.Text, tbFlatDUnit.Text);
                    pFlatD.setPrice(tbFlatD.Text);
                    populateFlatBarFields(pFlatD, tbFlatD, tbFlatDMeter, tbFlatDCost);
                    addFlatBarMSTotal(pFlatD.getCostperUnit());
                }
            }
            catch (FormatException)
            {
                tbFlatD.Text = "R0,00";
                tbFlatDMeter.Text = "";
                tbFlatDCost.Text = "";
                tbFlatD.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbCuttingDiscs_Leave(object sender, EventArgs e)
        {
            removeR(tbCuttingDiscs);
            
            try
            {
                if (pCuttingDiscs == null)
                {
                    pCuttingDiscs = new Sundries(tbCuttingDiscsQty.Text, tbCuttingDiscs.Text, tbCuttingDiscsUnits.Text);
                    populateSundriesFields(pCuttingDiscs, tbCuttingDiscs, tbCuttingDiscsValue, tbCuttingDiscsCost);
                    addSundriesTotal(pCuttingDiscs.getCostPerUnit());
                }
                else
                {
                    subtractSundriesTotal(pCuttingDiscs.getCostPerUnit());
                    pCuttingDiscs.setPrice(tbCuttingDiscs.Text);
                    populateSundriesFields(pCuttingDiscs, tbCuttingDiscs, tbCuttingDiscsValue, tbCuttingDiscsCost);
                    addSundriesTotal(pCuttingDiscs.getCostPerUnit());
                }
            }
            catch (FormatException)
            {
                tbCuttingDiscs.Text = "R0,00";
                tbCuttingDiscsValue.Text = "";
                tbCuttingDiscsCost.Text = "";
                tbCuttingDiscs.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbSanding_Leave(object sender, EventArgs e)
        {
            removeR(tbSanding);

            try
            {
                if (pSanding == null)
                {
                    pSanding = new Sundries(tbSandingQty.Text, tbSanding.Text, tbSandingUnits.Text);
                    populateSundriesFields(pSanding, tbSanding, tbSandingValue, tbSandingCost);
                    addSundriesTotal(pSanding.getCostPerUnit());
                }
                else
                {
                    subtractSundriesTotal(pSanding.getCostPerUnit());
                    pSanding.setPrice(tbSanding.Text);
                    populateSundriesFields(pSanding, tbSanding, tbSandingValue, tbSandingCost);
                    addSundriesTotal(pSanding.getCostPerUnit());
                }
            }
            catch (FormatException)
            {
                tbSanding.Text = "R0,00";
                tbSandingValue.Text = "";
                tbSandingCost.Text = "";
                tbSanding.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbDrill_Leave(object sender, EventArgs e)
        {
            removeR(tbDrill);

            try
            {
                if (pDrill == null)
                {
                    pDrill = new Sundries(tbDrillQty.Text, tbDrill.Text, tbDrillUnits.Text);
                    populateSundriesFields(pDrill, tbDrill, tbDrillValue, tbDrillCost);
                    addSundriesTotal(pDrill.getCostPerUnit());
                }
                else
                {
                    subtractSundriesTotal(pDrill.getCostPerUnit());
                    pDrill.setPrice(tbDrill.Text);
                    populateSundriesFields(pDrill, tbDrill, tbDrillValue, tbDrillCost);
                    addSundriesTotal(pDrill.getCostPerUnit());
                }

            }
            catch (FormatException)
            {
                tbDrill.Text = "R0,00";
                tbDrillValue.Text = "";
                tbDrillCost.Text = "";
                tbDrill.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbTap_Leave(object sender, EventArgs e)
        {
            removeR(tbTap);

            try
            {
                if (pTap == null)
                {
                    pTap = new Sundries(tbTapQty.Text, tbTap.Text, tbTapUnits.Text);
                    populateSundriesFields(pTap, tbTap, tbTapValue, tbTapCost);
                    addSundriesTotal(pTap.getCostPerUnit());
                }
                else
                {
                    subtractSundriesTotal(pTap.getCostPerUnit());
                    pTap.setPrice(tbTap.Text);
                    populateSundriesFields(pTap, tbTap, tbTapValue, tbTapCost);
                    addSundriesTotal(pTap.getCostPerUnit());
                }
            }
            catch (FormatException)
            {
                tbTap.Text = "R0,00";
                tbTapValue.Text = "";
                tbTapCost.Text = "";
                tbTap.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbGlue_Leave(object sender, EventArgs e)
        {
            removeR(tbGlue);


            try
            {
                if (pGlue == null)
                {
                    pGlue = new Sundries(tbGlueQty.Text, tbGlue.Text, tbGlueUnits.Text);
                    populateSundriesFields(pGlue, tbGlue, tbGlueValue, tbGlueCost);
                    addSundriesTotal(pGlue.getCostPerUnit());
                }
                else
                {
                    subtractSundriesTotal(pGlue.getCostPerUnit());
                    pGlue.setPrice(tbGlue.Text);
                    populateSundriesFields(pGlue, tbGlue, tbGlueValue, tbGlueCost);
                    addSundriesTotal(pGlue.getCostPerUnit());
                }
            }
            catch (FormatException)
            {
                tbGlue.Text = "R0,00";
                tbGlueValue.Text = "";
                tbGlueCost.Text = "";
                tbGlue.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbPottingBox_Leave(object sender, EventArgs e)
        {
            removeR(tbPottingBox);

            try
            {
                if (pPottingBox == null)
                {
                    pPottingBox = new Sundries(tbPottingBoxQty.Text, tbPottingBox.Text, tbPottingBoxUnits.Text);
                    populateSundriesFields(pPottingBox, tbPottingBox, tbPottingBoxValue, tbPottingBoxCost);
                    addSundriesTotal(pPottingBox.getCostPerUnit());
                }
                else
                {
                    subtractSundriesTotal(pPottingBox.getCostPerUnit());
                    pPottingBox.setPrice(tbPottingBox.Text);
                    populateSundriesFields(pPottingBox, tbPottingBox, tbPottingBoxValue, tbPottingBoxCost);
                    addSundriesTotal(pPottingBox.getCostPerUnit());
                }
            }
            catch (FormatException)
            {
                tbPottingBox.Text = "R0,00";
                tbPottingBoxValue.Text = "";
                tbPottingBoxCost.Text = "";
                tbPottingBox.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbWireLead_Leave(object sender, EventArgs e)
        {
            removeR(tbWireLead);

            try
            {
                if (pWireLead == null)
                {
                    pWireLead = new Sundries(tbWireLeadQty.Text, tbWireLead.Text, tbWireLeadUnits.Text);
                    populateSundriesFields(pWireLead, tbWireLead, tbWireLeadValue, tbWireLeadCost);
                    addSundriesTotal(pWireLead.getCostPerUnit());
                }
                else
                {
                    subtractSundriesTotal(pWireLead.getCostPerUnit());
                    pWireLead.setPrice(tbWireLead.Text);
                    populateSundriesFields(pWireLead, tbWireLead, tbWireLeadValue, tbWireLeadCost);
                    addSundriesTotal(pWireLead.getCostPerUnit());
                }
            }
            catch (FormatException)
            {
                tbWireLead.Text = "R0,00";
                tbWireLeadValue.Text = "";
                tbWireLeadCost.Text = "";
                tbWireLead.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbTapmatic_Leave(object sender, EventArgs e)
        {
            removeR(tbTapmatic);

            try
            {
                if (pTapmatic == null)
                {
                    pTapmatic = new Sundries(tbTapmaticQty.Text, tbTapmatic.Text, tbTapmaticUnits.Text);
                    populateSundriesFields(pTapmatic, tbTapmatic, tbTapmaticValue, tbTapmaticCost);
                    addSundriesTotal(pTapmatic.getCostPerUnit());
                }
                else
                {
                    subtractSundriesTotal(pTapmatic.getCostPerUnit());
                    pTapmatic.setPrice(tbTapmatic.Text);
                    populateSundriesFields(pTapmatic, tbTapmatic, tbTapmaticValue, tbTapmaticCost);
                    addSundriesTotal(pTapmatic.getCostPerUnit());
                }
            }
            catch (FormatException)
            {
                tbTapmatic.Text = "R0,00";
                tbTapmaticValue.Text = "";
                tbTapmaticCost.Text = "";
                tbTapmatic.Focus();
                MessageBox.Show("\tYou entered an incorrect value. \n\tPlease enter a number seperated by \".\" or \",\"", "Invalid Value Supplied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bRetry_Click(object sender, EventArgs e)
        {
            //Standard Steelworking
            
            if (pBraces != null)
            {
                pBraces = null;
            }

            if (pBraces1000 != null)
            {
                pBraces1000 = null;
            }

            if (pFeetBar != null)
            {
                pFeetBar = null;
            }

            if (pLoadcell != null)
            {
                pLoadcell = null;
            }

            if (pPotting != null)
            {
                pPotting = null;
            }

            if (pCable != null)
            {
                pCable = null;
            }

            if (pCutting != null)
            {
                pCutting = null;
            }

            if (pFeet != null)
            {
                pFeet = null;
            }

            if (pScrews != null)
            {
                pScrews = null;
            }

            if (pWeildingGas != null)
            {
                pWeildingGas = null;
            }

            if (pWeildingWire != null)
            {
                pWeildingWire = null;
            }

            if (pGalvanising != null)
            {
                pGalvanising = null;
            }

            if (pPetrol != null)
            {
                pPetrol = null;
            }

            if (pElecGlovGog != null)
            {
                pElecGlovGog = null;
            }

            if (pStickers != null)
            {
                pStickers = null;
            }
            
            if (pStickers1000 != null)
            {
                pStickers1000 = null;
            }

            if (pLabour != null)
            {
                pLabour = null;
            }

            clearTextbox(tbBraces, tbBracesUnitCost, tbBracesSetCost);
            clearTextbox(tbBraces1000, tbBraces1000UnitCost, tbBraces1000SetCost);
            clearTextbox(tbFeetBar, tbFeetBarUnitCost, tbFeetBarSetCost);
            clearTextbox(tbLoadcell, tbLoadcellUnitCost, tbLoadcellSetCost);
            clearTextbox(tbPotting, tbPottingUnitCost, tbPottingSetCost);
            clearTextbox(tbCable, tbCableUnitCost, tbCableSetCost);
            clearTextbox(tbCutting, tbCuttingCost, tbCuttingCost);
            clearTextbox(tbFeet, tbFeetCost, tbFeetCost);

            //HeavyDuty Steelworking

            if (pLoadPlate != null)
            {
                pLoadPlate = null;
            }

            if (pFootPlate != null)
            {
                pFootPlate = null;
            }

            if (pCellHousing != null)
            {
                pCellHousing = null;
            }

            if (pLoadBar != null)
            {
                pLoadBar = null;
            }

            if (pCableCover != null)
            {
                pCableCover = null;
            }

            if (pBrackets != null)
            {
                pBrackets = null;
            }

            if (pLoadPlateSecu != null)
            {
                pLoadPlateSecu = null;
            }

            if (pFootPlateSecu != null)
            {
                pFootPlateSecu = null;
            }

            if (pHDScrews != null)
            {
                pHDScrews = null;
            }

            if (pHDStickers != null)
            {
                pHDStickers = null;
            }

            clearTextbox(tbLoadPlate, tbLoadPlateCost, tbLoadPlateCost);
            clearTextbox(tbFootPlate, tbFootPlateCost, tbFootPlateCost);
            clearTextbox(tbCellHousing, tbCellHousingCost, tbCellHousingCost);
            clearTextbox(tbLoadBar, tbLoadBarCost, tbLoadBarCost);
            clearTextbox(tbCableCover, tbCableCoverCost, tbCableCoverCost);
            clearTextbox(tbBrackets, tbBracketsCost, tbBracketsCost);
            clearTextbox(tbLoadPlateSecu, tbLoadPlateSecuUnitCost, tbLoadPlateSecuCost);
            clearTextbox(tbFootPlateSecu, tbFootPlateSecuUnitCost, tbFootPlateSecuCost);
            clearTextbox(tbHDScrews, tbHDScrewsCost, tbHDScrewsCost);
            clearTextbox(tbHDStickers, tbHDStickersCost, tbHDStickersCost);

            clearTextbox(tbScrews, tbScrewsCost, tbScrewsCost);
            clearTextbox(tbWeildingGas, tbWeildingGasCost, tbWeildingGasCost);
            clearTextbox(tbWeildingWire, tbWeildingWireCost, tbWeildingWireCost);
            clearTextbox(tbGalvanising, tbGalvanisingCost, tbGalvanisingCost);
            clearTextbox(tbPetrol, tbPetrolCost, tbPetrolCost);
            clearTextbox(tbElecGlovGog, tbElecGlovGogCost, tbElecGlovGogCost);
            clearTextbox(tbStickers, tbStickersCost, tbStickersCost);
            clearTextbox(tbStickers1000, tbStickers1000Cost, tbStickers1000Cost);
            clearTextbox(tbLabour, tbLabourCost, tbLabourCost);

            //Loadcell Kit Costing

            if (pSingleLoadCell != null)
            {
                pSingleLoadCell = null;
            }

            if (pCable100A != null)
            {
                pCable100A = null;
            }

            if (pSpring != null)
            {
                pSpring = null;
            }

            if (pAmphenolPlugs != null)
            {
                pAmphenolPlugs = null;
            }

            if (pAmphenolCaps != null)
            {
                pAmphenolCaps = null;
            }

            clearTextbox(tbSingleLoadCell, tbSingleLoadCellUnitCost, tbSingleLoadCellCost);
            clearTextbox(tbCable100A, tbCable100AUnitCost, tbCable100ACost);
            clearTextbox(tbSpring, tbSpringUnitCost, tbSpringCost);
            clearTextbox(tbAmphenolPlugs, tbAmphenolPlugsUnitCost, tbAmphenolPlugsCost);
            clearTextbox(tbAmphenolCaps, tbAmphenolCapsUnitCost, tbAmphenolCapsCost);

            //QBooks
            clearTextbox(tbCellQBooks, tbCellQBooks, tbCellQBooks);
            clearTextbox(tbCableQBooks, tbCableQBooks, tbCableQBooks);
            clearTextbox(tbSpringQBooks, tbSpringQBooks, tbSpringQBooks);
            clearTextbox(tbPlugsQBooks, tbPlugsQBooks, tbPlugsQBooks);
            clearTextbox(tbCapsQBooks, tbCapsQBooks, tbCapsQBooks);

            //Workings

            if (pFlatA != null)
            {
                pFlatA = null;
            }

            if (pFlatB != null)
            {
                pFlatB = null;
            }

            if (pFlatC != null)
            {
                pFlatC = null;
            }

            if (pFlatD != null)
            {
                pFlatD = null;
            }

            if (pCuttingDiscs != null)
            {
                pCuttingDiscs = null;
            }

            if (pSanding != null)
            {
                pSanding = null;
            }

            if (pDrill != null)
            {
                pDrill = null;
            }

            if (pTap != null)
            {
                pTap = null;
            }

            if (pGlue != null)
            {
                pGlue = null;
            }

            if (pPottingBox != null)
            {
                pPottingBox = null;
            }

            if (pWireLead != null)
            {
                pWireLead = null;
            }

            if (pTapmatic != null)
            {
                pTapmatic = null;
            }

            clearTextbox(tbCuttingDiscs, tbCuttingDiscsCost, tbCuttingDiscsCost);
            clearTextbox(tbSanding, tbSandingCost, tbSandingCost);
            clearTextbox(tbDrill, tbDrillCost, tbDrillCost);
            clearTextbox(tbTap, tbTapCost, tbTapCost);
            clearTextbox(tbGlue, tbGlueCost, tbGlueCost);
            clearTextbox(tbPottingBox, tbPottingBoxCost, tbPottingBoxCost);
            clearTextbox(tbWireLead, tbWireLeadCost, tbWireLeadCost);
            clearTextbox(tbTapmatic, tbTapmaticCost, tbTapmaticCost);
            clearTextbox(tbFlatA, tbFlatAMeter, tbFlatACost);
            clearTextbox(tbFlatB, tbFlatBMeter, tbFlatBCost);
            clearTextbox(tbFlatC, tbFlatCMeter, tbFlatCCost);
            clearTextbox(tbFlatD, tbFlatDMeter, tbFlatDCost);

            tbFlatBarMSTotal.Text = "";
            tbSundriesTotal.Text = "";
            dFlatBarMSTotal = 0;
            dSundriesTotal = 0;

            tbLoadCellSubtotal.Text = "";
            dLoadCellSubTotal = 0;

            tbHDSubtotal.Text = "";
            tbSubtotal.Text = "";
            tbSubtotal1000.Text = "";
            tbMarkUpTotal.Text = "";
            tbTotalCost.Text = "";
            dHDSubtotal = 0;
            dSubtotal = 0;
            dMarkUp = 0;
            dTotal = 0;

    }

        private void bSavePDF_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Today;

            Document doc = new Document(iTextSharp.text.PageSize.A4, 30, 30, 30, 30);

            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Rudd Costing - " + dateTime.ToString("dd-MM-yyyy") + ".pdf", FileMode.Create));
            doc.Open();

            iTextSharp.text.Image Rudd = iTextSharp.text.Image.GetInstance("resources\\Rudd.jpg");
            Rudd.ScalePercent(50);
            Rudd.Alignment = Element.ALIGN_RIGHT;
            doc.Add(Rudd);

            Paragraph Space = new Paragraph("\n\n");
            doc.Add(Space);

            //Chunk chunk = new Chunk("This is from chunk. ");
            //doc.Add(chunk);

            //Phrase phrase = new Phrase("This is from Phrase.");
            //doc.Add(phrase);

            //Paragraph para = new Paragraph("This is from paragraph.");
            //doc.Add(para);

            //string text = @"you are successfully created PDF file.";
            //Paragraph paragraph1 = new Paragraph();
            //paragraph1.SpacingBefore = 10;
            //paragraph1.SpacingAfter = 10;
            //paragraph1.Alignment = Element.ALIGN_LEFT;
            //paragraph1.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f, BaseColor.GREEN);
            //paragraph1.Add(text);
            //doc.Add(paragraph);

            PdfPTable table = new PdfPTable(5);
            table.WidthPercentage = 100f;

            PdfPCell cell = new PdfPCell(new Phrase("600mm Steel Works", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 15)));
            cell.Colspan = 5;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            PdfPCell cellspace = new PdfPCell(new Phrase(" "));
            cellspace.Colspan = 5;

            int TabPage = tabControl1.SelectedIndex;

            
                table.AddCell("");
                table.AddCell("Price");
                table.AddCell("QTY");
                table.AddCell("Cost per Unit");
                table.AddCell("Cost per Set");
                
                table.AddCell("Steel Braces");
                table.AddCell(tbBraces.Text);
                table.AddCell(tbBracesQty.Text);
                table.AddCell(tbBracesUnitCost.Text);
                table.AddCell(tbBracesSetCost.Text);

                table.AddCell("Feet Bar Connectors");
                table.AddCell(tbFeetBar.Text);
                table.AddCell(tbFeetBarQty.Text);
                table.AddCell(tbFeetBarUnitCost.Text);
                table.AddCell(tbFeetBarSetCost.Text);

                table.AddCell("Loadcell Securer");
                table.AddCell(tbLoadcell.Text);
                table.AddCell(tbLoadcellQty.Text);
                table.AddCell(tbLoadcellUnitCost.Text);
                table.AddCell(tbLoadcellSetCost.Text);

                table.AddCell("Potting Box Securer");
                table.AddCell(tbPotting.Text);
                table.AddCell(tbPottingQty.Text);
                table.AddCell(tbPottingUnitCost.Text);
                table.AddCell(tbPottingSetCost.Text);

                table.AddCell("Cable Securer");
                table.AddCell(tbCable.Text);
                table.AddCell(tbCableQty.Text);
                table.AddCell(tbCableUnitCost.Text);
                table.AddCell(tbCableSetCost.Text);

                table.AddCell("Cutting and Bending");
                table.AddCell(tbCutting.Text);
                table.AddCell("");
                table.AddCell("");
                table.AddCell(tbCuttingCost.Text);

                table.AddCell("Feet");
                table.AddCell(tbFeet.Text);
                table.AddCell("");
                table.AddCell("");
                table.AddCell(tbFeetCost.Text);

            table.AddCell("M8 x 40 cap screws S/S");
            table.AddCell(tbScrews.Text);
            table.AddCell(tbScrewsQty.Text);
            table.AddCell("");
            table.AddCell(tbScrewsCost.Text);

            table.AddCell("Rudd Promotional Stickers");
            table.AddCell(tbStickers.Text);
            table.AddCell(tbStickersQty.Text);
            table.AddCell("");
            table.AddCell(tbStickersCost.Text);

            table.AddCell("Ash 5 - Welding gas");
            table.AddCell(tbWeildingGas.Text);
            table.AddCell("");
            table.AddCell("");
            table.AddCell(tbWeildingGasCost.Text);

            table.AddCell("Welding Wire");
            table.AddCell(tbWeildingWire.Text);
            table.AddCell("");
            table.AddCell("");
            table.AddCell(tbWeildingWireCost.Text);

            table.AddCell("Galvanising");
            table.AddCell(tbGalvanising.Text);
            table.AddCell("");
            table.AddCell("");
            table.AddCell(tbGalvanisingCost.Text);

            table.AddCell("Petrol");
            table.AddCell(tbPetrol.Text);
            table.AddCell("");
            table.AddCell("");
            table.AddCell(tbPetrolCost.Text);

            table.AddCell("Electricity, Gloves, Goggles");
            table.AddCell(tbElecGlovGog.Text);
            table.AddCell("");
            table.AddCell("");
            table.AddCell(tbElecGlovGogCost.Text);

            table.AddCell("Labour Cost");
            table.AddCell(tbLabour.Text);
            table.AddCell(tbLabourQty.Text);
            table.AddCell("");
            table.AddCell(tbLabourCost.Text);

            table.AddCell(cellspace);

            doc.Add(table);

            Paragraph Steelwork = new Paragraph("600mm Subtotal: " + tbSubtotal.Text);
            Steelwork.SpacingBefore = 10;
            Steelwork.SpacingAfter = 10;
            Steelwork.Alignment = Element.ALIGN_RIGHT;
            Steelwork.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f);
            doc.Add(Steelwork);

            doc.NewPage();

            doc.Add(Rudd);

            doc.Add(Space);

            PdfPTable tableB = new PdfPTable(5);
            tableB.WidthPercentage = 100f;

            PdfPCell cellB = new PdfPCell(new Phrase("1000mm Steel Works", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 15)));
            cellB.Colspan = 5;
            cellB.HorizontalAlignment = Element.ALIGN_CENTER;
            tableB.AddCell(cellB);

            PdfPCell cellspaceB = new PdfPCell(new Phrase(" "));
            cellspaceB.Colspan = 5;

            int TabPageB = tabControl1.SelectedIndex;


            tableB.AddCell("");
            tableB.AddCell("Price");
            tableB.AddCell("QTY");
            tableB.AddCell("Cost per Unit");
            tableB.AddCell("Cost per Set");

            tableB.AddCell("Steel Braces 1000mm");
            tableB.AddCell(tbBraces1000.Text);
            tableB.AddCell(tbBraces1000Qty.Text);
            tableB.AddCell(tbBraces1000UnitCost.Text);
            tableB.AddCell(tbBraces1000SetCost.Text);

            tableB.AddCell("Feet Bar Connectors");
            tableB.AddCell(tbFeetBar.Text);
            tableB.AddCell(tbFeetBarQty.Text);
            tableB.AddCell(tbFeetBarUnitCost.Text);
            tableB.AddCell(tbFeetBarSetCost.Text);

            tableB.AddCell("Loadcell Securer");
            tableB.AddCell(tbLoadcell.Text);
            tableB.AddCell(tbLoadcellQty.Text);
            tableB.AddCell(tbLoadcellUnitCost.Text);
            tableB.AddCell(tbLoadcellSetCost.Text);

            tableB.AddCell("Potting Box Securer");
            tableB.AddCell(tbPotting.Text);
            tableB.AddCell(tbPottingQty.Text);
            tableB.AddCell(tbPottingUnitCost.Text);
            tableB.AddCell(tbPottingSetCost.Text);

            tableB.AddCell("Cable Securer");
            tableB.AddCell(tbCable.Text);
            tableB.AddCell(tbCableQty.Text);
            tableB.AddCell(tbCableUnitCost.Text);
            tableB.AddCell(tbCableSetCost.Text);

            tableB.AddCell("Cutting and Bending");
            tableB.AddCell(tbCutting.Text);
            tableB.AddCell("");
            tableB.AddCell("");
            tableB.AddCell(tbCuttingCost.Text);

            tableB.AddCell("Feet");
            tableB.AddCell(tbFeet.Text);
            tableB.AddCell("");
            tableB.AddCell("");
            tableB.AddCell(tbFeetCost.Text);

            tableB.AddCell("M8 x 40 cap screws S/S");
            tableB.AddCell(tbScrews.Text);
            tableB.AddCell(tbScrewsQty.Text);
            tableB.AddCell("");
            tableB.AddCell(tbScrewsCost.Text);

            tableB.AddCell("1000mm Rudd Promotional Stickers");
            tableB.AddCell(tbStickers1000.Text);
            tableB.AddCell(tbStickers1000Qty.Text);
            tableB.AddCell("");
            tableB.AddCell(tbStickers1000Cost.Text);

            tableB.AddCell("Ash 5 - Welding gas");
            tableB.AddCell(tbWeildingGas.Text);
            tableB.AddCell("");
            tableB.AddCell("");
            tableB.AddCell(tbWeildingGasCost.Text);

            tableB.AddCell("Welding Wire");
            tableB.AddCell(tbWeildingWire.Text);
            tableB.AddCell("");
            tableB.AddCell("");
            tableB.AddCell(tbWeildingWireCost.Text);

            tableB.AddCell("Galvanising");
            tableB.AddCell(tbGalvanising.Text);
            tableB.AddCell("");
            tableB.AddCell("");
            tableB.AddCell(tbGalvanisingCost.Text);

            tableB.AddCell("Petrol");
            tableB.AddCell(tbPetrol.Text);
            tableB.AddCell("");
            tableB.AddCell("");
            tableB.AddCell(tbPetrolCost.Text);

            tableB.AddCell("Electricity, Gloves, Goggles");
            tableB.AddCell(tbElecGlovGog.Text);
            tableB.AddCell("");
            tableB.AddCell("");
            tableB.AddCell(tbElecGlovGogCost.Text);

            tableB.AddCell("Labour Cost");
            tableB.AddCell(tbLabour.Text);
            tableB.AddCell(tbLabourQty.Text);
            tableB.AddCell("");
            tableB.AddCell(tbLabourCost.Text);

            tableB.AddCell(cellspaceB);

            doc.Add(tableB);

            Paragraph Steelwork1000 = new Paragraph("1000mm Subtotal: " + tbSubtotal1000.Text);
            Steelwork1000.SpacingBefore = 10;
            Steelwork1000.SpacingAfter = 10;
            Steelwork1000.Alignment = Element.ALIGN_RIGHT;
            Steelwork1000.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f);
            doc.Add(Steelwork1000);

            doc.NewPage();
            
            doc.Add(Rudd);

            doc.Add(Space);

            PdfPTable tableA = new PdfPTable(5);
            tableA.WidthPercentage = 100f;

            PdfPCell cellA = new PdfPCell(new Phrase("Heavy Duty Steel Works", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 15)));
            cellA.Colspan = 5;
            cellA.HorizontalAlignment = Element.ALIGN_CENTER;
            tableA.AddCell(cellA);

            tableA.AddCell("");
            tableA.AddCell("Price");
            tableA.AddCell("QTY");
            tableA.AddCell("Cost per Unit");
            tableA.AddCell("Cost per Set");

            tableA.AddCell("Top Load Plate (650mm)");
                tableA.AddCell(tbLoadPlate.Text);
                tableA.AddCell(tbLoadPlateQty.Text);
                tableA.AddCell("");
                tableA.AddCell(tbLoadPlateCost.Text);

                tableA.AddCell("Foot Plate");
                tableA.AddCell(tbFootPlate.Text);
                tableA.AddCell(tbFootPlateQty.Text);
                tableA.AddCell("");
                tableA.AddCell(tbFootPlateCost.Text);

                tableA.AddCell("Load Cell Housing");
                tableA.AddCell(tbCellHousing.Text);
                tableA.AddCell(tbCellHousingQty.Text);
                tableA.AddCell("");
                tableA.AddCell(tbCellHousingCost.Text);

                tableA.AddCell("Load Bar Top Cover Channel");
                tableA.AddCell(tbLoadBar.Text);
                tableA.AddCell(tbLoadBarQty.Text);
                tableA.AddCell("");
                tableA.AddCell(tbLoadBarCost.Text);

                tableA.AddCell("Cable Cover Angle");
                tableA.AddCell(tbCableCover.Text);
                tableA.AddCell(tbCableCoverQty.Text);
                tableA.AddCell("");
                tableA.AddCell(tbCableCoverCost.Text);

                tableA.AddCell("Brackets Top Hat");
                tableA.AddCell(tbBrackets.Text);
                tableA.AddCell(tbBracketsQty.Text);
                tableA.AddCell("");
                tableA.AddCell(tbBracketsCost.Text);

                tableA.AddCell("Top Load Plate Securing Block");
                tableA.AddCell(tbLoadPlateSecu.Text);
                tableA.AddCell(tbLoadPlateSecuQty.Text);
                tableA.AddCell(tbLoadPlateSecuUnitCost.Text);
                tableA.AddCell(tbLoadPlateSecuCost.Text);

                tableA.AddCell("Foot Plate Securing Block");
                tableA.AddCell(tbFootPlateSecu.Text);
                tableA.AddCell(tbFootPlateSecuQty.Text);
                tableA.AddCell(tbFootPlateSecuUnitCost.Text);
                tableA.AddCell(tbFootPlateSecuCost.Text);

            tableA.AddCell("M8 x 40 cap screws S/S");
            tableA.AddCell(tbHDScrews.Text);
            tableA.AddCell(tbHDScrewsQty.Text);
            tableA.AddCell("");
            tableA.AddCell(tbHDScrewsCost.Text);

            tableA.AddCell("Rudd Promotional Stickers");
            tableA.AddCell(tbHDStickers.Text);
            tableA.AddCell(tbHDStickersQty.Text);
            tableA.AddCell("");
            tableA.AddCell(tbHDStickersCost.Text);

            tableA.AddCell("Ash 5 - Welding gas");
            tableA.AddCell(tbWeildingGas.Text);
            tableA.AddCell("");
            tableA.AddCell("");
            tableA.AddCell(tbWeildingGasCost.Text);

            tableA.AddCell("Welding Wire");
            tableA.AddCell(tbWeildingWire.Text);
            tableA.AddCell("");
            tableA.AddCell("");
            tableA.AddCell(tbWeildingWireCost.Text);

            tableA.AddCell("Galvanising");
            tableA.AddCell(tbGalvanising.Text);
            tableA.AddCell("");
            tableA.AddCell("");
            tableA.AddCell(tbGalvanisingCost.Text);

            tableA.AddCell("Petrol");
            tableA.AddCell(tbPetrol.Text);
            tableA.AddCell("");
            tableA.AddCell("");
            tableA.AddCell(tbPetrolCost.Text);

            tableA.AddCell("Electricity, Gloves, Goggles");
            tableA.AddCell(tbElecGlovGog.Text);
            tableA.AddCell("");
            tableA.AddCell("");
            tableA.AddCell(tbElecGlovGogCost.Text);

            tableA.AddCell("Labour Cost");
            tableA.AddCell(tbLabour.Text);
            tableA.AddCell(tbLabourQty.Text);
            tableA.AddCell("");
            tableA.AddCell(tbLabourCost.Text);

            tableA.AddCell(cellspace);

            doc.Add(tableA);

            Paragraph HDSteelwork = new Paragraph("Heavy Duty Subtotal: " + tbHDSubtotal.Text);
            HDSteelwork.SpacingBefore = 10;
            HDSteelwork.SpacingAfter = 10;
            HDSteelwork.Alignment = Element.ALIGN_RIGHT;
            HDSteelwork.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f);
            doc.Add(HDSteelwork);

            doc.Add(Space);


            PdfPTable table1 = new PdfPTable(6);
            table1.WidthPercentage = 100f;
            float[] widths = new float[] { 10f, 10f, 5f, 10f, 20f, 10f };
            table1.SetWidths(widths);

            PdfPCell cell1 = new PdfPCell(new Phrase("Flat bar MS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 15)));
            cell1.Colspan = 6;
            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            table1.AddCell(cell1);

            table1.AddCell("Size");
            table1.AddCell("Price");
            table1.AddCell("QTY");
            table1.AddCell("Unit Size");
            table1.AddCell("Meter / Unit");
            table1.AddCell("Cost per Set");
     
            table1.AddCell("25 x 3mm");
            table1.AddCell(tbFlatA.Text);
            table1.AddCell(tbFlatAQty.Text);
            table1.AddCell(tbFlatAUnit.Text);
            table1.AddCell(tbFlatAMeter.Text);
            table1.AddCell(tbFlatACost.Text);

            table1.AddCell("60 x 16mm");
            table1.AddCell(tbFlatB.Text);
            table1.AddCell(tbFlatBQty.Text);
            table1.AddCell(tbFlatBUnit.Text);
            table1.AddCell(tbFlatBMeter.Text);
            table1.AddCell(tbFlatBCost.Text);

            table1.AddCell("40 x 4,5mm");
            table1.AddCell(tbFlatC.Text);
            table1.AddCell(tbFlatCQty.Text);
            table1.AddCell(tbFlatCUnit.Text);
            table1.AddCell(tbFlatCMeter.Text);
            table1.AddCell(tbFlatCCost.Text);

            table1.AddCell("50 x 12mm");
            table1.AddCell(tbFlatD.Text);
            table1.AddCell(tbFlatDQty.Text);
            table1.AddCell(tbFlatDUnit.Text);
            table1.AddCell(tbFlatDMeter.Text);
            table1.AddCell(tbFlatDCost.Text);

            doc.Add(table1);

            Paragraph FlatBarMS = new Paragraph("Flat Bar MS total: " + tbFlatBarMSTotal.Text);
            FlatBarMS.SpacingBefore = 10;
            FlatBarMS.SpacingAfter = 10;
            FlatBarMS.Alignment = Element.ALIGN_RIGHT;
            FlatBarMS.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f);
            doc.Add(FlatBarMS);

            doc.NewPage();

            doc.Add(Rudd);

            doc.Add(Space);

            PdfPTable table2 = new PdfPTable(7);
            table2.WidthPercentage = 100f;

            PdfPCell cell2 = new PdfPCell(new Phrase("Sundries", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 15)));
            cell2.Colspan = 7;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            table2.AddCell(cell2);

            table2.AddCell(" ");
            table2.AddCell("Used/Month");
            table2.AddCell("Price per Sundary");
            table2.AddCell("Sub Value");
            table2.AddCell("Units Made / Month");
            table2.AddCell("QBooks");
            table2.AddCell("Cost per Set");

            table2.AddCell("Cutting Discs");
            table2.AddCell(tbCuttingDiscsQty.Text);
            table2.AddCell(tbCuttingDiscs.Text);
            table2.AddCell(tbCuttingDiscsValue.Text);
            table2.AddCell(tbCuttingDiscsUnits.Text);
            table2.AddCell(" ");
            table2.AddCell(tbCuttingDiscsCost.Text);

            table2.AddCell("Sanding Discs");
            table2.AddCell(tbSandingQty.Text);
            table2.AddCell(tbSanding.Text);
            table2.AddCell(tbSandingValue.Text);
            table2.AddCell(tbSandingUnits.Text);
            table2.AddCell(" ");
            table2.AddCell(tbSandingCost.Text);

            table2.AddCell("Drill Bits");
            table2.AddCell(tbDrillQty.Text);
            table2.AddCell(tbDrill.Text);
            table2.AddCell(tbDrillValue.Text);
            table2.AddCell(tbDrillUnits.Text);
            table2.AddCell(" ");
            table2.AddCell(tbDrillCost.Text);

            table2.AddCell("Tap (for threading)");
            table2.AddCell(tbTapQty.Text);
            table2.AddCell(tbTap.Text);
            table2.AddCell(tbTapValue.Text);
            table2.AddCell(tbTapUnits.Text);
            table2.AddCell(" ");
            table2.AddCell(tbTapCost.Text);

            table2.AddCell("Glue Sticks");
            table2.AddCell(tbGlueQty.Text);
            table2.AddCell(tbGlue.Text);
            table2.AddCell(tbGlueValue.Text);
            table2.AddCell(tbGlueUnits.Text);
            table2.AddCell(" ");
            table2.AddCell(tbGlueCost.Text);

            table2.AddCell("Potting Boxes");
            table2.AddCell(tbPottingBoxQty.Text);
            table2.AddCell(tbPottingBox.Text);
            table2.AddCell(tbPottingBoxValue.Text);
            table2.AddCell(tbPottingBoxUnits.Text);
            table2.AddCell(tbPottingQBooks.Text);
            table2.AddCell(tbPottingBoxCost.Text);

            table2.AddCell("Wire Leaders");
            table2.AddCell(tbWireLeadQty.Text);
            table2.AddCell(tbWireLead.Text);
            table2.AddCell(tbWireLeadValue.Text);
            table2.AddCell(tbWireLeadUnits.Text);
            table2.AddCell(" ");
            table2.AddCell(tbWireLeadCost.Text);

            table2.AddCell("Tapmatic");
            table2.AddCell(tbTapmaticQty.Text);
            table2.AddCell(tbTapmatic.Text);
            table2.AddCell(tbTapmaticValue.Text);
            table2.AddCell(tbTapmaticUnits.Text);
            table2.AddCell(" ");
            table2.AddCell(tbTapmaticCost.Text);

            doc.Add(table2);

            Paragraph Sundries = new Paragraph("Sundries total: " + tbSundriesTotal.Text);
            Sundries.SpacingBefore = 10;
            Sundries.SpacingAfter = 10;
            Sundries.Alignment = Element.ALIGN_RIGHT;
            Sundries.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f);
            doc.Add(Sundries);

            doc.Add(Space);

            PdfPTable table3 = new PdfPTable(6);
            table3.WidthPercentage = 100f;

            PdfPCell cell3 = new PdfPCell(new Phrase("Loadcell Kit", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 15)));
            cell3.Colspan = 6;
            cell3.HorizontalAlignment = Element.ALIGN_CENTER;
            table3.AddCell(cell3);

            table3.AddCell(" ");
            table3.AddCell("Price");
            table3.AddCell("QTY");
            table3.AddCell("Price per Unit");
            table3.AddCell("QBooks");
            table3.AddCell("Price per Set");

            table3.AddCell("Single Load Cell");
            table3.AddCell(tbSingleLoadCell.Text);
            table3.AddCell(tbSingleLoadCellQty.Text);
            table3.AddCell(tbSingleLoadCellUnitCost.Text);
            table3.AddCell(tbCellQBooks.Text);
            table3.AddCell(tbSingleLoadCellCost.Text);

            table3.AddCell("Cable (100m)");
            table3.AddCell(tbCable100A.Text);
            table3.AddCell(tbCable100AQty.Text);
            table3.AddCell(tbCable100AUnitCost.Text);
            table3.AddCell(tbCableQBooks.Text);
            table3.AddCell(tbCable100ACost.Text);

            table3.AddCell("Spring Protector");
            table3.AddCell(tbSpring.Text);
            table3.AddCell(tbSpringQty.Text);
            table3.AddCell(tbSpringUnitCost.Text);
            table3.AddCell(tbSpringQBooks.Text);
            table3.AddCell(tbSpringCost.Text);

            table3.AddCell("Amphenol Plugs");
            table3.AddCell(tbAmphenolPlugs.Text);
            table3.AddCell(tbAmphenolPlugsQty.Text);
            table3.AddCell(tbAmphenolPlugsUnitCost.Text);
            table3.AddCell(tbPlugsQBooks.Text);
            table3.AddCell(tbAmphenolPlugsCost.Text);

            table3.AddCell("Amphenol Caps");
            table3.AddCell(tbAmphenolCaps.Text);
            table3.AddCell(tbAmphenolCapsQty.Text);
            table3.AddCell(tbAmphenolCapsUnitCost.Text);
            table3.AddCell(tbCapsQBooks.Text);
            table3.AddCell(tbAmphenolCapsCost.Text);

            doc.Add(table3);

            Paragraph LoadcellKit = new Paragraph("Loadcell Kit total: " + tbLoadCellSubtotal.Text);
            LoadcellKit.SpacingBefore = 10;
            LoadcellKit.SpacingAfter = 10;
            LoadcellKit.Alignment = Element.ALIGN_RIGHT;
            LoadcellKit.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f);
            doc.Add(LoadcellKit);

            doc.Add(Space);

            Paragraph MarkUp = new Paragraph("MarkUp total: " + tbMarkUpTotal.Text);
            MarkUp.SpacingBefore = 10;
            MarkUp.SpacingAfter = 10;
            MarkUp.Alignment = Element.ALIGN_RIGHT;
            MarkUp.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f);
            doc.Add(MarkUp);

            Paragraph TotalCost = new Paragraph("Total Cost: " + tbTotalCost.Text);
            TotalCost.SpacingBefore = 10;
            TotalCost.SpacingAfter = 10;
            TotalCost.Alignment = Element.ALIGN_RIGHT;
            TotalCost.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f);
            doc.Add(TotalCost);

            doc.Close();
            MessageBox.Show("File has been saved as PDF.", "File Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clearTextbox(TextBox tbPrice, TextBox tbCostPerUnit, TextBox tbCostPerSet)
        {
            tbPrice.Text = "R0,00";
            tbCostPerUnit.Text = "";
            tbCostPerSet.Text = "";
        }

        private void populateFields(Parts p, String qty, String price, String type, TextBox tbOrigPriceBox, TextBox tbOrigUnitCost, TextBox tbOrigSetCost)
        {
            tbOrigPriceBox.Text = setText(tbOrigPriceBox.Text.Replace(".", ","));

            tbOrigUnitCost.Text = setText(p.getUnitPrice().ToString());

            tbOrigSetCost.Text = setText(p.getSetPrice().ToString());
        }

        private void populateSundriesFields(Sundries s,TextBox tbOrigPriceBox, TextBox tbOrigUnitCost, TextBox tbOrigSetCost)
        {
            tbOrigPriceBox.Text = setText(tbOrigPriceBox.Text.Replace(".", ","));

            tbOrigUnitCost.Text = setText(s.getSubValue().ToString());

            tbOrigSetCost.Text = setText(s.getCostPerUnit().ToString());
        }

        private void bNotesSave_Click(object sender, EventArgs e)
        {
            rtbNotes.SaveFile(@"RuddNotes.rtf");
        }

        private void bNotesReload_Click(object sender, EventArgs e)
        {
            try
            {
                rtbNotes.LoadFile(@"RuddNotes.rtf");
            }
            catch (System.IO.FileNotFoundException fnfe)
            {
                MessageBox.Show("There is nothing to load at this time. Try adding some Notes and saving them first.", "No File to Load", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void populateFlatBarFields(FlatBar s, TextBox tbOrigPriceBox, TextBox tbOrigUnitCost, TextBox tbOrigSetCost)
        {
            tbOrigPriceBox.Text = setText(tbOrigPriceBox.Text.Replace(".", ","));

            tbOrigUnitCost.Text = s.getUnitSize().ToString();

            tbOrigSetCost.Text = setText(s.getCostperUnit().ToString());
        }

        private String setText(String tb)
        {
            string amt = "R0,00";

            double amount = 0.0d;
            if (Double.TryParse(tb, NumberStyles.Currency, null, out amount))
            {
                amt = amount.ToString("C");
            }
            return amt;
        }

        private void addSubtotal(Double price)
        {
            dSubtotal = dSubtotal + price;
            tbSubtotal.Text = setText(dSubtotal.ToString());
            addTotalCost(dSubtotal);
        }

        private void addSubtotal1000(Double price)
        {
            dSubtotal1000 = dSubtotal1000 + price;
            tbSubtotal1000.Text = setText(dSubtotal1000.ToString());
            addTotalCost(dSubtotal1000);
        }

        private void addHDSubtotal(Double price)
        {
            dHDSubtotal = dHDSubtotal + price;
            tbHDSubtotal.Text = setText(dHDSubtotal.ToString());
            addTotalCost(dHDSubtotal);
        }

        private void subtractSubTotal(Double price)
        {
            dSubtotal = dSubtotal - price;
            tbSubtotal.Text = setText(dSubtotal.ToString());
        }

        private void subtractSubTotal1000(Double price)
        {
            dSubtotal1000 = dSubtotal1000 - price;
            tbSubtotal1000.Text = setText(dSubtotal1000.ToString());
        }

        private void subtractHDSubTotal(Double price)
        {
            dHDSubtotal = dHDSubtotal - price;
            tbHDSubtotal.Text = setText(dHDSubtotal.ToString());
        }

        private void addLoadCellKitTotal(Double price)
        {
            dLoadCellSubTotal = dLoadCellSubTotal + price;
            tbLoadCellSubtotal.Text = setText(dLoadCellSubTotal.ToString());
            addTotalCost(dLoadCellSubTotal);
        }

        private void subtractLoadCellKitTotal(Double price)
        {
            dLoadCellSubTotal = dLoadCellSubTotal - price;
            tbLoadCellSubtotal.Text = setText(dLoadCellSubTotal.ToString());
        }

        private void addFlatBarMSTotal(Double price)
        {
            dFlatBarMSTotal = dFlatBarMSTotal + price;
            tbFlatBarMSTotal.Text = setText(dFlatBarMSTotal.ToString());
            addTotalCost(dFlatBarMSTotal);
        }

        private void subtractFlatBarMSTotal(Double price)
        {
            dFlatBarMSTotal = dFlatBarMSTotal - price;
            tbFlatBarMSTotal.Text = setText(dFlatBarMSTotal.ToString());
        }

        private void addSundriesTotal(Double price)
        {
            dSundriesTotal = dSundriesTotal + price;
            tbSundriesTotal.Text = setText(dSundriesTotal.ToString());
            addTotalCost(dSundriesTotal);
        }

        private void subtractSundriesTotal(Double price)
        {
            dSundriesTotal = dSundriesTotal - price;
            tbSundriesTotal.Text = setText(dSundriesTotal.ToString());
        }

        private void addTotalCost(Double price)
        {
            dMarkUp = (dSubtotal+ dSubtotal1000 +dHDSubtotal + dLoadCellSubTotal + dSundriesTotal + dFlatBarMSTotal) * (Convert.ToDouble(tbMarkupAmount.Text) / 100);
            dTotal = (dSubtotal+ dSubtotal1000 +dHDSubtotal + dLoadCellSubTotal + dSundriesTotal + dFlatBarMSTotal) + dMarkUp;
            tbMarkUpTotal.Text = setText(dMarkUp.ToString());
            tbTotalCost.Text = setText(dTotal.ToString());
        }

        private void removeR(TextBox tb)
        {
            if (tb.Text.StartsWith("R"))
            {
                tb.Text = tb.Text.Replace("R", "");
            }
        }

    }
}

/*************************************************************************
  OptionsDialog.java
   
  Java Signature Capture

  Copyright (c) 2025 Wacom. All rights reserved.
  
***************************************************************************/

package com.wacom.sdk.sample;

import javax.swing.*;
import java.awt.*;
import java.util.ArrayList;
import java.util.List;

import com.wacom.signature.Configuration;


public class OptionsDialog extends JDialog {
  
  /*
   *  Utility class to support use of JColorChooser dialog
   */
  private class ChooseColorButton extends JButton {
    private JTextField  txtValue;
    
    public ChooseColorButton(JTextField txt) {
      super("...");
      this.txtValue = txt;
      
      addActionListener(e -> {
        String strValue = txtValue.getText();
        Color color = null;
        if (strValue != null && strValue.length() == 7 && strValue.charAt(0) == '#') {
          color = new Color(Integer.parseInt(strValue.substring(1, 3), 16), 
                            Integer.parseInt(strValue.substring(3, 5), 16), 
                            Integer.parseInt(strValue.substring(5, 7), 16));
        }
        color = JColorChooser.showDialog(this, "Choose Color", color);
        if (color != null) {
          txtValue.setText(String.format("#%02x%02x%02x", color.getRed(), color.getGreen(), color.getBlue()));
        }
      });
    }
  }
    
  private Configuration sigCaptConfig;

  private JTextField         txtWinCaption   = new JTextField(32);
  private JTextField         txtWinBkgnd     = new JTextField(7);
  private JComboBox<String>  cbxFontName     = new JComboBox<>(new String[]{"Verdana", "Georgia", "Consolas", "Calibri"});
  private JComboBox<Integer> cbxFontSize     = new JComboBox<>(new Integer[]{10, 12, 14});
  private JCheckBox          chkFontBold     = new JCheckBox("Bold");
  private JTextField         txtSigAreaBkgnd = new JTextField(7);
  private JTextField         txtSigAreaInk   = new JTextField(7);

  /**
   * Constructor. Set up dialog controls
   */
  public OptionsDialog(Frame parent, Configuration config) {
    super(parent, "GroupLayout Dialog with Titled Borders", true);

    this.sigCaptConfig = config;

    JPanel contentPanel = new JPanel();
    contentPanel.setLayout(new BoxLayout(contentPanel, BoxLayout.Y_AXIS));
    contentPanel.setBorder(BorderFactory.createEmptyBorder(10, 10, 10, 10));

    // Group 1: Window
    JPanel group1 = createTitledGroup("Window");
    addLabeledRow(group1, "Caption:", txtWinCaption);
    addLabeledRow(group1, "Background color:", txtWinBkgnd, new ChooseColorButton(txtWinBkgnd));
    contentPanel.add(group1);
    contentPanel.add(Box.createVerticalStrut(10));

    // Group 2: Text
    JPanel group2 = createTitledGroup("Text");
    addLabeledRow(group2, "Font:", cbxFontName, cbxFontSize);
    addLabeledRow(group2, "", chkFontBold);
    contentPanel.add(group2);
    contentPanel.add(Box.createVerticalStrut(10));

    // Group 3: Signature Area
    JPanel group3 = createTitledGroup("Signature Area");

    addLabeledRow(group3, "Background:", txtSigAreaBkgnd, new ChooseColorButton(txtSigAreaBkgnd));
    addLabeledRow(group3, "Ink:", txtSigAreaInk, new ChooseColorButton(txtSigAreaInk));
    contentPanel.add(group3);
    contentPanel.add(Box.createVerticalStrut(20));

    // OK/Cancel buttons
    JPanel buttonPanel = new JPanel(new FlowLayout(FlowLayout.RIGHT));
    JButton okButton = new JButton("OK");
    JButton cancelButton = new JButton("Cancel");
    okButton.addActionListener(e -> {
      setConfig();
      dispose();
    });
    cancelButton.addActionListener(e -> dispose());
    buttonPanel.add(okButton);
    buttonPanel.add(cancelButton);
    contentPanel.add(buttonPanel);

    setContentPane(contentPanel);
    pack();
    setLocationRelativeTo(parent);
    
    getConfig();
  }

  /**
   * Display the dialog
   */
  public void showDialog() {
    setVisible(true);
  }

  /*
   * Retrieve values from Signature Capture Configuration and display them in the dialog
   */
  private void getConfig() {
    String  caption = (String)sigCaptConfig.getValue("CaptureWindow.Caption");
    String  bkgnd = (String)sigCaptConfig.getValue("CaptureWindow.BackgroundColor");
    String  fontName = (String)sigCaptConfig.getValue("CaptureWindow.OutsideFont.Facename");
    Integer fontSize = (Integer)sigCaptConfig.getValue("CaptureWindow.OutsideFont.Size");
    String  fontWeight = (String)sigCaptConfig.getValue("CaptureWindow.OutsideFont.Weight");
    String  sigAreaBkgnd = (String)sigCaptConfig.getValue("CaptureWindow.SignatureArea.Color");
    String  sigAreaInk   = (String)sigCaptConfig.getValue("CaptureWindow.SignatureArea.Ink.Color"); 

    if (caption != null)
      txtWinCaption.setText(caption);
    if (bkgnd != null)
      txtWinBkgnd.setText(bkgnd);
      
    if (fontName != null) {
      cbxFontName.setSelectedItem(fontName);
    }
    if (fontSize!= null) {
      cbxFontSize.setSelectedItem(fontSize);
    }
    if (fontWeight != null) {
      chkFontBold.setSelected(fontWeight.equals("bold"));
    }
    
    if (sigAreaBkgnd != null)
      txtSigAreaBkgnd.setText(sigAreaBkgnd);
    if (sigAreaInk != null)
      txtSigAreaInk.setText(sigAreaInk);
    
  }

  /*
   * Retrieve values from the dialog and set Signature Capture Configuration 
   */
  private void setConfig() {
    String  caption = txtWinCaption.getText();
    String  bkgnd = txtWinBkgnd.getText();
    String  fontName = (String)cbxFontName.getSelectedItem();
    Integer fontSize = (Integer)cbxFontSize.getSelectedItem();
    boolean fontBold = chkFontBold.isSelected();
    String  sigAreaBkgnd = txtSigAreaBkgnd.getText();
    String  sigAreaInk   = txtSigAreaInk.getText();

    if (caption != null)
      sigCaptConfig.setValue("CaptureWindow.Caption", caption);
    if (bkgnd != null)
      sigCaptConfig.setValue("CaptureWindow.BackgroundColor", bkgnd);
    if (fontName != null) {
      sigCaptConfig.setValue("CaptureWindow.OutsideFont.Facename", fontName); 
      sigCaptConfig.setValue("CaptureWindow.InsideFont.Facename", fontName); 
      sigCaptConfig.setValue("CaptureWindow.Buttons.Font.Facename", fontName); 
    }
    if (fontSize != null) {
      sigCaptConfig.setValue("CaptureWindow.OutsideFont.Size", fontSize);
      sigCaptConfig.setValue("CaptureWindow.InsideFont.Size", fontSize);
      sigCaptConfig.setValue("CaptureWindow.Buttons.Font.Size", fontSize);
    }
    sigCaptConfig.setValue("CaptureWindow.OutsideFont.Weight", fontBold ? "bold" : "normal");
    sigCaptConfig.setValue("CaptureWindow.InsideFont.Weight", fontBold ? "bold" : "normal");
    sigCaptConfig.setValue("CaptureWindow.Buttons.Font.Weight", fontBold ? "bold" : "normal");
    if (sigAreaBkgnd != null)
      sigCaptConfig.setValue("CaptureWindow.SignatureArea.Color", sigAreaBkgnd);
    if (sigAreaInk != null)
      sigCaptConfig.setValue("CaptureWindow.SignatureArea.Ink.Color", sigAreaInk);
    
  }
  
  /*
   * Helper to create a titled group panel using GroupLayout 
   */
  private JPanel createTitledGroup(String title) {
    JPanel panel = new JPanel();
    panel.setBorder(BorderFactory.createTitledBorder(title));

    GroupLayout layout = new GroupLayout(panel);
    panel.setLayout(layout);
    layout.setAutoCreateGaps(true);
    layout.setAutoCreateContainerGaps(true);

    // Store rows in lists to append dynamically
    List<GroupLayout.Group> hLabels = new ArrayList<>();
    List<GroupLayout.Group> hFields = new ArrayList<>();
    List<GroupLayout.Group> vRows = new ArrayList<>();

    panel.putClientProperty("layout", layout);
    panel.putClientProperty("hLabels", hLabels);
    panel.putClientProperty("hFields", hFields);
    panel.putClientProperty("vRows", vRows);

    return panel;
  }

  /*
   * Helper to add a labeled row with optional trailing components (eg, text field + button) 
   */
  private void addLabeledRow(JPanel panel, String labelText, JComponent field, JComponent... extras) {
    GroupLayout layout = (GroupLayout) panel.getClientProperty("layout");
    @SuppressWarnings("unchecked")
    List<GroupLayout.Group> hLabels = (List<GroupLayout.Group>) panel.getClientProperty("hLabels");
    @SuppressWarnings("unchecked")
    List<GroupLayout.Group> hFields = (List<GroupLayout.Group>) panel.getClientProperty("hFields");
    @SuppressWarnings("unchecked")
    List<GroupLayout.Group> vRows = (List<GroupLayout.Group>) panel.getClientProperty("vRows");

    JLabel label = new JLabel(labelText);

    // Horizontal field group: text field + any extra buttons
    GroupLayout.SequentialGroup fieldRow = layout.createSequentialGroup()
        .addComponent(field);
    for (JComponent extra : extras) {
        fieldRow.addPreferredGap(LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(extra);
    }

    // Add to horizontal groups
    hLabels.add(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(label));
    hFields.add(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(fieldRow));

    // Vertical row: label + field + extras (all aligned baseline)
    GroupLayout.ParallelGroup vGroup = layout.createParallelGroup(GroupLayout.Alignment.BASELINE)
        .addComponent(label)
        .addComponent(field);
    for (JComponent extra : extras) {
        vGroup.addComponent(extra);
    }
    vRows.add(vGroup);

    // Rebuild layout
    GroupLayout.SequentialGroup hGroup = layout.createSequentialGroup();
    GroupLayout.ParallelGroup hLabelGroup = layout.createParallelGroup(GroupLayout.Alignment.LEADING);
    GroupLayout.ParallelGroup hFieldGroup = layout.createParallelGroup(GroupLayout.Alignment.LEADING);
    for (GroupLayout.Group g : hLabels) {
      hLabelGroup.addGroup(g);
    }
    for (GroupLayout.Group g : hFields) {
      hFieldGroup.addGroup(g);
    }
    hGroup.addGroup(hLabelGroup).addGroup(hFieldGroup);
    layout.setHorizontalGroup(hGroup);

    GroupLayout.SequentialGroup vGroupList = layout.createSequentialGroup();
    for (GroupLayout.Group g : vRows) {
      vGroupList.addGroup(g);
    }
    layout.setVerticalGroup(vGroupList);
  }

}

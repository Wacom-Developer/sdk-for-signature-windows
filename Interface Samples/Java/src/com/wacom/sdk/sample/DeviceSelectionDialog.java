/*************************************************************************
  DeviceSelectionDialog.java
   
  Java Signature Capture

  Copyright (c) 2025 Wacom. All rights reserved.
  
***************************************************************************/

package com.wacom.sdk.sample;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.image.BufferedImage;

import java.io.File;
import java.io.IOException;
import java.util.List;

import javax.imageio.ImageIO;

import javax.swing.*;
import javax.swing.border.TitledBorder;

//import com.florentis.signature.SigCtl;
import com.florentis.signature.SigObj;

import com.wacom.signature.CaptureWindow;
import com.wacom.signature.Configuration;
import com.wacom.signature.CreateCaptureWindowResult;
import com.wacom.signature.Enums;
import com.wacom.signature.SignatureCapture;
import com.wacom.signature.SignatureDevice;
import com.wacom.signature.SignatureDeviceList;

/**
 * Device Selection Dialog
 */
public class DeviceSelectionDialog extends JDialog {
    private SignatureDevice selectedSignatureDevice = null;

  /**
   * Constructor. Set up dialog controls
   */
  public DeviceSelectionDialog(JFrame parent, SignatureDeviceList deviceList) {
    super(parent, "Select Capture Device", true); // modal
    setSize(300, 250);
    setLocationRelativeTo(parent);
    setLayout(new BorderLayout());

    DefaultListModel < SignatureDevice > model = new DefaultListModel <> ();
    deviceList.forEach(model:: addElement);

    JList < SignatureDevice > list = new JList <> (model);
    list.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
    list.setCellRenderer(new SignatureDeviceCellRenderer());
    add(new JScrollPane(list), BorderLayout.CENTER);

    JPanel buttonPanel = new JPanel();
    JButton okButton = new JButton("OK");
    JButton cancelButton = new JButton("Cancel");

    okButton.addActionListener(e -> {
      selectedSignatureDevice = list.getSelectedValue();
      dispose();
    });

    cancelButton.addActionListener(e -> {
      selectedSignatureDevice = null;
      dispose();
    });

    buttonPanel.add(okButton);
    buttonPanel.add(cancelButton);
    add(buttonPanel, BorderLayout.SOUTH);
  }

  /**
   * Display the dialog
   */
  public SignatureDevice showDialog() {
    setVisible(true);
    return selectedSignatureDevice;
  }

  /**
   * Custom renderer for displaying device names in listbox
   */
  static class SignatureDeviceCellRenderer extends JLabel implements ListCellRenderer < SignatureDevice > {
    public SignatureDeviceCellRenderer() {
      setOpaque(true);
    }

    @Override
    public Component getListCellRendererComponent(JList <? extends SignatureDevice > list, SignatureDevice value,
      int index, boolean isSelected, boolean cellHasFocus) {
      setText(value.name());
      setFont(new Font("SansSerif", Font.PLAIN, 14));
      setBackground(isSelected ? list.getSelectionBackground() : list.getBackground());
      setForeground(isSelected ? list.getSelectionForeground() : list.getForeground());
      return this;
    }
  }
}


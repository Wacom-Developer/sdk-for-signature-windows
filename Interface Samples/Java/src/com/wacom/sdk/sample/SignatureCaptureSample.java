/*************************************************************************
  SignatureCaptureSample.java
   
  Java Signature Capture

  The project displays a form with a button to start signature capture
  The captured signature is encoded in an image file which is displayed on the form
  
  Copyright (c) 2025 Wacom. All rights reserved.
  
***************************************************************************/

package com.wacom.sdk.sample;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Component;
import java.awt.Container;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.image.BufferedImage;

import java.io.File;
import java.io.IOException;
import java.util.List;

import javax.imageio.ImageIO;

import javax.swing.JButton;
import javax.swing.JDialog;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JList;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.JTextField;
import javax.swing.border.TitledBorder;
import javax.swing.BoxLayout;
import javax.swing.DefaultListModel;
import javax.swing.ListCellRenderer;
import javax.swing.ListSelectionModel;

import com.florentis.signature.SigCtl;
import com.florentis.signature.SigObj;

import com.wacom.signature.CaptureWindow;
import com.wacom.signature.Configuration;
import com.wacom.signature.CreateCaptureWindowResult;
import com.wacom.signature.Enums;
import com.wacom.signature.SignatureCapture;
import com.wacom.signature.SignatureDevice;
import com.wacom.signature.SignatureDeviceList;


public class SignatureCaptureSample extends JFrame implements CaptureWindow.ICaptureWindowEvents {
    private static final String LICENSE_STR = 
"eyJhbGciOiJSUzUxMiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJMTVMiLCJleHAiOjE3NTY1NDQyNDIsImlhdCI6MTcyNTAwODI3NiwicmlnaHRzIjpbIlNJR19TREtfQ09SRSJdLCJkZXZpY2VzIjpbIldBQ09NX0FOWSJdLCJ0eXBlIjoiZXZhbCIsImxpY19uYW1lIjoiVGVzdCBsaWNlbnNlIFsxNzI1MDA4MjQyXSIsIndhY29tX2lkIjoiMTUzYmU4OWYtOTYzNy00YWI0LTk5OTktOTRlMGM4ZTBkMmEzIiwibGljX3VpZCI6IjU4ODdjNzc5LTZkODUtNDlkNy1hNTAyLTlhOTEyOWQ3NTIyYSIsImFwcHNfd2luZG93cyI6W10sImFwcHNfaW9zIjpbXSwiYXBwc19hbmRyb2lkIjpbXSwibWFjaGluZV9pZHMiOltdfQ.TjB6HtI6ENW06edvUHz3IwYNoca9s5hXR8KvTg-koAt0EowyHiFmDnvHtvUCeQatvvLlxgqm6G-fD1fHhyU2auMHZBgOL4BE1m_pUWyzKRv7ILCFhotI8d8hHWybTK8jikTVR7KPrEhMh5sPAZ-JfGkRDfsGM3kFH0HniFqO9PBYxcqspqY_h9AdIFQ1PKG7LzHx88-e-hPAW7sCa4SinTKfcYVxcYRsPlkUnGgtCGfg77q2yj1yoSL2ffbP26QeAyOOGoLHNP9EpE7b5gHpFpIKUt2gU65sFV9iD86Gyh4zdi_Gmsh59AOFf0c_Q_Kf2Vnt8KCIJ0Ptllh7dIT0qQ";
//"eyJhbGciOiJSUzUxMiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImV4cCI6MjE0NzQ4MzY0NywiaWF0IjoxNzQxNzkxNDU4LCJzZWF0cyI6MCwicmlnaHRzIjpbIlNJR19TREtfQ09SRSIsIlNJR19TREtfSVNPIiwiU0lHX1NES19FTkNSWVBUSU9OIiwiU0lHTkFUVVJFX1NES19BQ0NFU1MiLCJTSUdOUFJPX0FDQ0VTUyIsIlNJR05QUk9fQVBJX0FDQ0VTUyIsIkJBWFRFUl9BQ0NFU1MiLCJTSUdfU0RLX1JFTU9URV9TQyJdLCJkZXZpY2VzIjpbIldBQ09NX0FOWSIsIlJUUyJdLCJ0eXBlIjoiZXZhbCIsImxpY19uYW1lIjoiRW1iZWRkZWQgc2lnbiBwcm8gdjQgYW5kIFJlbW90ZSBFdmFsdWF0aW9uIE1vZGUiLCJ3YWNvbV9pZCI6IjdiYzljYjFhYjEwYTQ2ZTE4MjY3YTkxMmRhMDZlMjc2IiwibGljX3VpZCI6ImNlNTRlYjYxLTRkOTgtNDE3My1hYjdhLTEzYzMxYjI2ZDdmMiIsImFwcHNfd2luZG93cyI6W10sImFwcHNfaW9zIjpbXSwiYXBwc19hbmRyb2lkIjpbXSwibWFjaGluZV9pZHMiOltdLCJ3d3ciOltdLCJiYWNrZW5kX2lkcyI6W119.q0TlqoNMOeVadB_pD-6muKn6mVN47F7lqkyCsVgXotlqjF01VDtXloiXk_ZByFyHCdUH6t6_eZ83BP0kopfpeLRFjPOuj8JXRWlmJrdwr6ClP5IW9_gAxvLBtee6gEOAAlXbVutdyrPpdRyuEeUsCrw2FzYbgpfOpuLMrtHQRQCpbedY3tfyrKuSwlj9ZE6D8OATWba0ItmxcwAOZUcaohELu3BZiVLTQICYtpX84JrgOB3xi_TbPMUfXvSUxXtPkimAYzVDpp19myjXbRkJUrLdNLyubWVuGXxi8fySFSLmHU2ComKSUlhzUOrpuHSpC5f5rOkXUEnfvjJtBmYz5A";
    private static final String SIG_IMAGE_FILENAME = "signature.png";
    
    private JPanel drawPanel;
    private JTextArea textArea;
    private JButton signBtn;
    private JButton optionsBtn;
    
    private BufferedImage signatureImage;
    private SignatureCapture sigCapt;

    public static void main(String args[]) {
        SignatureCaptureSample frame = new SignatureCaptureSample();
        frame.setVisible(true);
    }

    /**
     * Constructor. Set up main window
     */
    public SignatureCaptureSample() {
        // Initialize window
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setTitle("Signature Capture Sample");
        this.setSize(new Dimension(450, 350));
        this.setLayout(new BorderLayout());

        // Add Panel to display image of captured signture
        drawPanel = new JPanel() {
            @Override
            public void paintComponent(Graphics g) {
                super.paintComponent(g);
                if (signatureImage != null) {
                    g.drawImage(signatureImage, 0, 0, null);
                }
            }
        };
        drawPanel.setBackground(Color.WHITE);
        drawPanel.setPreferredSize(new Dimension(200, 150));
        
        JPanel panelImage = new JPanel();
        panelImage.add(drawPanel);

        this.add(panelImage, BorderLayout.WEST);

        // Add button to initiate signature capture
        signBtn = new JButton("Sign");
        signBtn.setPreferredSize(new Dimension(100, 50));
        signBtn.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent evt) {
                trace("Sign button was pressed");
                sign();
            }
        });
        
        // Add button to show options dialog
        optionsBtn = new JButton("Options");
        optionsBtn.setPreferredSize(new Dimension(100, 50));
        optionsBtn.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent evt) {
                setOptions();
            }
        });
        JPanel panelButton = new JPanel();
        panelButton.setLayout(new BoxLayout(panelButton, BoxLayout.Y_AXIS));
        panelButton.add(signBtn);
        panelButton.add(optionsBtn);
        
        this.add(panelButton, BorderLayout.EAST);

        // Add TextArea to display status messages
        textArea = new JTextArea(8, 20);
        textArea.setEditable(false);
        this.add(new JScrollPane(textArea), BorderLayout.SOUTH);

        // Create and enable SignatureCapture
        this.sigCapt = new SignatureCapture();
        Enums.LicenseStatus licenseStatus = sigCapt.license().add(LICENSE_STR);
        if (licenseStatus != Enums.LicenseStatus.Licensed) {
          trace("Licensing error: " + licenseStatus);
          //signBtn.setEnabled(false);
        }
    }

    public void trace(String str) {
      textArea.append(str + "\n");
      textArea.setCaretPosition(textArea.getDocument().getLength());
    }
    
    /**
     * Initiate signature capture
     */
    private void sign() {
        // STEP 1: get list of capture devices
        SignatureDeviceList deviceList = sigCapt.getDeviceList();

		try {
			if (deviceList.count() == 0) {
				trace("No Capture device found");
			}
			else {      
				// STEP 2: display list of devices for user to select one
				DeviceSelectionDialog dialog = new DeviceSelectionDialog(this, deviceList);
				SignatureDevice device = dialog.showDialog();

				if (device != null) {
					// STEP 3: create the capture window
					CreateCaptureWindowResult captWndResult = sigCapt.createCaptureWindow(device, "Who", "Why", null, this);
				
					if (captWndResult != null)  {
						trace("Capture window status: " + captWndResult.status.captureResult);
					
						// disable "Sign" button while capture is in progress
						if (captWndResult.status.captureResult == Enums.CaptureResult.CaptureResult_Pending)
							signBtn.setEnabled(false);
					}
					else {
						trace("createCaptureWindow failed");
					}
				}
			}
		}
		catch (Exception e) {
			trace("Exception: " + e.getMessage());
		}
    }

    /* 
     * Show dialog to set options
     */
    private void setOptions()
    {
      String color = null;

      OptionsDialog dialog = new OptionsDialog(this, sigCapt.configuration());
      dialog.showDialog();
    }
    
    /**
     * Reads a (signature) image file and displays the image
     */
    private void paintSignature(String fileName) {
        try {
            signatureImage = ImageIO.read(new File(fileName));
            drawPanel.repaint();

        }
        catch (IOException e) {
            System.out.println(e.toString());
        }
    }
    
    // CaptureWindow.ICaptureWindowEvents Methods
    
    /**
     * Callback for signature started event
     *
     * @param sender            the CaptureWindow object 
     */
    public void OnSignatureStarted(CaptureWindow sender) {
        trace("Callback received: SignatureStarted");
    }
    
    /**
     * Callback for capture window button click event
     *
     * @param sender      the CaptureWindow object 
     * @param buttonId    Id of button clicked (Ok, Clear or Cancel)
     */
    public void OnButtonClick(CaptureWindow sender, Enums.ButtonId buttonId) {
        trace("Callback received: ButtonClick " + buttonId);
    }
    
    /**
     * Callback for error event
     *
     * @param sender            the CaptureWindow object 
     * @param errorType         type of error
     * @param errorDescription  may give further information on the error
     */
    public void OnError(CaptureWindow sender, Enums.CaptureResult errorType, String description) {
        trace("Callback received: Error " + errorType);
        if (description != null)
            trace(" \"" + description + "\"");
    }
  
    /**
     * Callback for capture window closed event
     *
     * @param sender            the CaptureWindow object 
     * @param errorType         Reason for window closing
     * @param errorDescription  if result is an error, may give further information
     */
    public void OnClose(CaptureWindow sender, Enums.CaptureResult result, String errorDescription) {
        trace("Callback received: capture window closed");
        switch (result) {
            case CaptureResult_Success:
                trace("  Signature captured successfully");

                // Get signature data from capture window in text format
                String sigText = (String)sender.getSignature(Enums.SignatureStorageType.SigText); 

                // Initialize a SigObj with the signature data
                SigObj sigObj = new SigObj();
                sigObj.sigText(sigText);
                
                // Save signature as an image with steganographically encoded signature data
                int flags = SigObj.outputFilename | SigObj.color32BPP | SigObj.encodeData;
                sigObj.renderBitmap(SIG_IMAGE_FILENAME, 
                    200, 150,             // Size of image in pixels
                    "image/png",          // image file type
                    0.5f,                 // ink width
                    0xff0000,             // ink color (blue)
                    0xffffff,             // background color (white)
                    0.0f, 0.0f,           // padding
                    flags);
                    
                // Display captured signature
                paintSignature(SIG_IMAGE_FILENAME);
                break;

            case CaptureResult_Cancelled:
                trace("  Capture cancelled");
                break;

            default:
                trace("  Capture failed, error code: " + result);
                if (errorDescription != null)
                    trace("  " + errorDescription);
                break;
        }
        // Re-enable Sign button
        signBtn.setEnabled(true);
    }

}

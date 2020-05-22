/*************************************************************************
  TestWizSigCapt.java
   
  Java Signature Capture using Wizard script

  The project displays a form with a button to start signature capture using the Wizard script
  The captured signature is encoded in an image file which is displayed on the form
  
  Copyright (c) 2015 Wacom GmbH. All rights reserved.
  
***************************************************************************/

package com.wacom.sdk.sample;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.text.DefaultCaret;

import com.florentis.signature.SigCtl;
import com.florentis.signature.SigObj;
import com.florentis.signature.WizCtl;

public class TestWizSigCapt extends JFrame {
	
  private static final long serialVersionUID = 1L;
  
  private JPanel drawPanel;
  private JTextArea textArea;
  private BufferedImage signatureImage;
  
  private Thread tWizard;
  private boolean scriptIsRunning = false;
  private MyWizardScript myWizardScript;
  
  public TestWizSigCapt() {
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setTitle("TestWizSigCapt");
		this.setSize(new Dimension(450,350));
		this.setLayout(new BorderLayout());

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
		drawPanel.setPreferredSize(new Dimension(200,150));
		

		JPanel panelImage = new JPanel();
		panelImage.add(drawPanel);
		
		this.add(panelImage,BorderLayout.WEST);
			
		JButton btnSign = new JButton("Sign");
		btnSign.setPreferredSize(new Dimension(100,50));
		btnSign.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent evt) {
				if (!scriptIsRunning) {
          scriptIsRunning = true;
					textArea.append("Sign...\n");
					myWizardScript = new MyWizardScript();
					tWizard = new Thread(myWizardScript);
					tWizard.start();
		  	} else {
		  		textArea.append("Script is already running\n");				
				}
			}
		});
		
		JButton btnCancel = new JButton("Cancel");
		btnCancel.setPreferredSize(new Dimension(100,50));
		btnCancel.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent evt) {
				textArea.append("Cancel...\n");
				if (scriptIsRunning) {
					myWizardScript.closeWizard();
		  	} else {
		  		textArea.append("Script is not running\n");				
				}
			}
		});		
		
		JPanel panelButton = new JPanel();
		panelButton.setLayout(new BorderLayout());
		panelButton.add(btnSign,BorderLayout.NORTH);
		panelButton.add(btnCancel,BorderLayout.SOUTH);
		
		this.add(panelButton, BorderLayout.EAST);
		
    textArea = new JTextArea(8,20);
    textArea.setEditable(false);

    DefaultCaret caret = (DefaultCaret)textArea.getCaret();
    caret.setUpdatePolicy(DefaultCaret.ALWAYS_UPDATE);

    JScrollPane scrollPane = new JScrollPane();
    scrollPane.setViewportView(textArea);
    this.add(scrollPane, BorderLayout.SOUTH);
				
  }     
  
	public static void main(String args[]) {
		TestWizSigCapt frame = new TestWizSigCapt();
		frame.setVisible(true);
	}

	class MyWizardScript implements Runnable {
	  
	  private String model;
	  private WizCtl.Font textFont;
	  private WizCtl.Font buttonFont;
	  private WizCtl.Font sigLineFont;
	  private int textLs;
	  private int buttonWidth;	 
	  
	  private WizCtl wizCtl;
	  private SigCtl sigCtl;
	  private SigObj sigObj;
	    
	  public void run() {
      try {
  		  wizCtl = new WizCtl();
        wizCtl.licence("<<license>>");
        
  		  sigCtl = new SigCtl();
        sigCtl.licence("<<license>>");
        
  		  sigObj = sigCtl.signature();

  		  wizCtl.setEventHandler(new WizCtl.WizCtlEvents() {

 			  public boolean onPadEvent(WizCtl ctl, String id, Object type) {
 				   if ("Ok".equals(id)) {
 					   scriptCompleted();
 				   } else if ("Clear".equals(id)) {
 					   textArea.append("Clear\n");
 				   } else if ("Cancel".equals(id)) {
 					   scriptCancelled();
 				   } else {
 					   textArea.append("Unexpected pad event: "+id+"\n");
 				   }
 	         return true;
          }
 			
 		    });		
 		    startWizard();
 		    try {
          wizCtl.processEvents();
        } catch (InterruptedException e) {
          //e.printStackTrace();
          textArea.append("run interrupted\n");
        }	
        wizCtl.close();
        sigCtl.close();
        sigObj.close();          		  	
        wizCtl = null;
        sigCtl = null;
        sigObj = null;
      }
      catch (Exception e) {
        textArea.append("Exception: " + e + "\n");
        e.printStackTrace();
      }	          		  	
      scriptIsRunning = false;
	  }

		private void startWizard() {
			textArea.append("startWizard\n");
	    
			boolean success = wizCtl.padConnect();
			if (success) {
				textArea.append("Pad detected " + wizCtl.padWidth() + " x "+ wizCtl.padHeight()+"\n");
				if (wizCtl.padHeight() > 100) {
					textArea.append("STU-500\n");
					pad500();
				} else {
					textArea.append("STU-300\n");
					pad300();
				}
				step1();
			}
      else {
        textArea.append("padConnect FAILED\n");
      }
	  }
		
		private void pad500() {
			model = "STU-500";
			
			textFont = new WizCtl.Font();
			textFont.name = "Verdana";
			textFont.size = 16;
			
			buttonFont = new WizCtl.Font();
			buttonFont.name = "Verdana";
			buttonFont.size = 22;
			
			sigLineFont = new WizCtl.Font();
			sigLineFont.name = "Verdana";
			sigLineFont.size = 32;
			
			textLs = 30;
			buttonWidth = 110;
			
		}
		
		private void pad300() {
			model = "STU-300";
			
			textFont = new WizCtl.Font();
			textFont.name = "Verdana";
			textFont.size = 8;
			
			buttonFont = new WizCtl.Font();
			buttonFont.name = "Verdana";
			buttonFont.size = 8;
			
			sigLineFont = new WizCtl.Font();
			sigLineFont.name = "Verdana";
			sigLineFont.size = 16;
			
			textLs = 12;
			buttonWidth = 70;
			
		}	
		
		private void step1() {
			int x,y = 0;
			wizCtl.reset();
			
			// insert message
			wizCtl.setFont(textFont);
			wizCtl.addObject(WizCtl.objectText, "txt", "centre", 10, "Please sign below...", null);
			
			// insert a signature line
			wizCtl.setFont(sigLineFont);
			y = (int)(wizCtl.padHeight() * 0.6);
			wizCtl.addObject(WizCtl.objectText, "txt", "centre", y, "X..............................", null);
			
			// insert the signature control
			wizCtl.setFont(textFont);
			wizCtl.addObject(WizCtl.objectSignature, "Sig", 0, 0, sigObj, null);
			
	    // provide who and why for sig capture
	    y += 2 * textLs;
	    if (model == "STU-300")
	        y = wizCtl.padHeight() + 10; // put text off screen (no display)
	    wizCtl.addObject(WizCtl.objectText, "who", "right", y, "J Smith", null);
	    y += textLs;
	    wizCtl.addObject(WizCtl.objectText, "why", "right", y, "I certify that the information is correct", null);

	    // insert the buttons
	    wizCtl.setFont(buttonFont);
	    int xmargin, ymargin;
	    xmargin = ymargin = 20;
	    if (model == "STU-300") { xmargin = 5; ymargin = 0; }
	    y = (int)(wizCtl.padHeight() - textLs - ymargin);
	    x = xmargin;
	    wizCtl.addObject(WizCtl.objectButton, "Cancel", x, y, "Cancel", buttonWidth);
	    wizCtl.addObject(WizCtl.objectButton, "Clear", "center", y, "Clear", buttonWidth);
	    x = wizCtl.padWidth() - buttonWidth - xmargin;
	    wizCtl.addObject(WizCtl.objectButton, "Ok", x, y, "OK", buttonWidth);
	    	
	    wizCtl.display();
	     
		}
		
		private void scriptCompleted() {
			textArea.append("scriptCompleted\n");
			if (sigObj.isCaptured()) {
				sigObj.extraData("AdditionalData", "C# Wizard test: Additional data");
	      String filename = "sig1.png";
	      int flags = SigObj.outputFilename | SigObj.color32BPP | SigObj.encodeData;
	      sigObj.renderBitmap(filename, 200, 150, "image/png", 0.5f, 0xff0000, 0xffffff, 0.0f, 0.0f, flags );
	      paintSignature(filename);
	      closeWizard();
			}
		}
		
		private void scriptCancelled() {
      try {
			  textArea.append("scriptCancelled\n");
			  closeWizard();			
      }
      catch (Exception e) {
        textArea.append("Exception: " + e);
      }
		}
		
		private void closeWizard() {
			textArea.append("closeWizard\n");
			
			wizCtl.reset();
			wizCtl.display();
			wizCtl.padDisconnect();
			wizCtl.setEventHandler(null);
      wizCtl.endProcessEvents();
		}
		
		private void paintSignature(String fileName) {
			try
	    {
		    signatureImage = ImageIO.read(new File(fileName));
		    drawPanel.repaint();
		    
	    } catch (IOException e)
	    {
	    	System.out.println(e.toString());
	    }
		}	
		
	}	
	
}



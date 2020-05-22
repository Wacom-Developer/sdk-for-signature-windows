/*************************************************************************
  WizardScript.java
   
  Java Signature Capture using Wizard script

  Demonstrates signature capture via a wizard script
  
  Copyright (c) 2015 Wacom GmbH. All rights reserved.
  
***************************************************************************/
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

import com.florentis.signature.SigCtl;
import com.florentis.signature.SigObj;
import com.florentis.signature.WizCtl;

public class WizardScript extends JFrame {

	private static final long serialVersionUID = 1L;

	private JPanel drawPanel;
	private JTextArea textArea;
	private BufferedImage signatureImage;

	private Thread tWizard;
	private boolean scriptIsRunning = false;
	private MyWizardScript myWizardScript;

	public WizardScript() {
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setTitle("TestWizSigCapt");
		this.setSize(new Dimension(450, 350));
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
		drawPanel.setPreferredSize(new Dimension(200, 150));

		JPanel panelImage = new JPanel();
		panelImage.add(drawPanel);

		this.add(panelImage, BorderLayout.WEST);

		JButton btnSign = new JButton("Sign");
		btnSign.setPreferredSize(new Dimension(100, 50));
		btnSign.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent evt) {
				if (!scriptIsRunning) {
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
		btnCancel.setPreferredSize(new Dimension(100, 50));
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
		panelButton.add(btnSign, BorderLayout.NORTH);
		panelButton.add(btnCancel, BorderLayout.SOUTH);

		this.add(panelButton, BorderLayout.EAST);

		textArea = new JTextArea(8, 20);
		textArea.setEditable(false);
		this.add(new JScrollPane(textArea), BorderLayout.SOUTH);

	}

	public static void main(String args[]) {
		WizardScript frame = new WizardScript();
		frame.setVisible(true);
	}

	class MyWizardScript implements Runnable {

		private class TPad {
			private String model;
			private WizCtl.Font textFont;
			private WizCtl.Font buttonFont;
			private WizCtl.Font sigLineFont;
			private int buttonWidth;
			private int signatureLineY;
			private int whoY;
			private int whyY;

			private TPad(String model, int signatureLineY, int whoY, int whyY,
					int textFontSize, int buttonFontSize, int signLineSize,
					int buttonWidth) {

				this.model = model;
				this.signatureLineY = signatureLineY;
				this.whoY = whoY;
				this.whyY = whyY;
				this.buttonWidth = buttonWidth;

				textFont = new WizCtl.Font();
				textFont.name = "Verdana";
				textFont.size = textFontSize;

				buttonFont = new WizCtl.Font();
				buttonFont.name = "Verdana";
				buttonFont.size = buttonFontSize;

				sigLineFont = new WizCtl.Font();
				sigLineFont.name = "Verdana";
				sigLineFont.size = signLineSize;

			}
		}

		private TPad pad;
		private WizCtl wizCtl;
		private SigCtl sigCtl;
		private SigObj sigObj;
		private boolean isCheck;

		public void run() {
			wizCtl = new WizCtl();
      wizCtl.licence("<<license>>");
      
			sigCtl = new SigCtl();
      sigCtl.licence("<<license>>");
      
			sigObj = sigCtl.signature();

			wizCtl.setEventHandler(new WizCtl.WizCtlEvents() {

				public boolean onPadEvent(WizCtl ctl, String id, Object type) {
					textArea.append("Pad Event: " + id);
					if ("Ok".equals(id)) {
						scriptCompleted();
					} else if ("Clear".equals(id)) {
						textArea.append("Clear\n");
					} else if ("Cancel".equals(id)) {
						scriptCancelled();
					} else if ("Check".equals(id)) {
						isCheck = !isCheck;
					} else if ("Next".equals(id)) {
						if (isCheck)
							step2();
					} else {
						textArea.append("Unexpected pad event: " + id + "\n");
					}
					return true;
				}

			});
			startWizard();
			try {
				wizCtl.processEvents();
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
		}

		private void startWizard() {
			textArea.append("startWizard\n");

			boolean success = wizCtl.padConnect();
			if (success) {
				scriptIsRunning = true;
				isCheck = false;
				textArea.append("Pad detected " + wizCtl.padWidth() + " x "
						+ wizCtl.padHeight() + "\n");

				switch (wizCtl.padWidth()) {
				case 396:
					pad = new TPad("STU-300", 60, 200, 200, 8, 8, 16, 70); // 396x100
					break;
				case 640:
					pad = new TPad("STU-500", 300, 360, 390, 16, 22, 32, 110); // 640x800
					break;
				case 800:
					pad = new TPad("STU-520 or STU-530", 300, 360, 390, 16, 22, 32, 110); // 800x480
					break;
				case 320:
					pad = new TPad("STU-430 or ePad", 100, 130, 150, 10, 12, 16, 110); // 320x200
					break;
				default:
					textArea.append("No compatible device found\n");
				}
				textArea.append(pad.model + "\n");
				step1();
			}
		}
		
		private void step1() {
			wizCtl.reset();

			// insert checkbox
			wizCtl.setFont(pad.textFont);
			wizCtl.addObject(WizCtl.objectCheckbox, "Check", "centre", "middle",
					"I have read and I accept the terms and conditions", 2);

			// insert the buttons
			wizCtl.setFont(pad.buttonFont);
			wizCtl.addObject(WizCtl.objectButton, "Cancel", "left",
						"bottom", "Cancel", pad.buttonWidth);
			wizCtl.addObject(WizCtl.objectButton, "Next", "right", "bottom",
						"Next", pad.buttonWidth);

			wizCtl.display();
		}		

		private void step2() {
			wizCtl.reset();

			// insert message
			wizCtl.setFont(pad.textFont);
			wizCtl.addObject(WizCtl.objectText, "txt", "centre", "top",
					"Please sign below...", null);

			// insert a signature line
			wizCtl.setFont(pad.sigLineFont);
			if (pad.model == "STU-300")
				wizCtl.addObject(WizCtl.objectText, "txt", "left",
						pad.signatureLineY, "X..............................",
						null);
			else
				wizCtl.addObject(WizCtl.objectText, "txt", "centre",
						pad.signatureLineY, "X..............................",
						null);

			// insert the signature control
			wizCtl.setFont(pad.textFont);
			wizCtl.addObject(WizCtl.objectSignature, "Sig", 0, 0, sigObj, null);

			// provide who and why for sig capture
			wizCtl.addObject(WizCtl.objectText, "who", "right", pad.whoY,
					"J Smith", null);
			wizCtl.addObject(WizCtl.objectText, "why", "right", pad.whyY,
					"I certify that the information is correct", null);

			// insert the buttons
			wizCtl.setFont(pad.buttonFont);
			if (pad.model == "STU-300") {
				wizCtl.addObject(WizCtl.objectButton, "Cancel", "right",
						"top", "Cancel", pad.buttonWidth);
				wizCtl.addObject(WizCtl.objectButton, "Clear", "right",
						"middle", "Clear", pad.buttonWidth);
				wizCtl.addObject(WizCtl.objectButton, "Ok", "right", "bottom",
						"OK", pad.buttonWidth);
			} else {
				wizCtl.addObject(WizCtl.objectButton, "Cancel", "left",
						"bottom", "Cancel", pad.buttonWidth);
				wizCtl.addObject(WizCtl.objectButton, "Clear", "center",
						"bottom", "Clear", pad.buttonWidth);
				wizCtl.addObject(WizCtl.objectButton, "Ok", "right", "bottom",
						"OK", pad.buttonWidth);
			}

			wizCtl.display();
		}

		private void scriptCompleted() {
			textArea.append("scriptCompleted\n");
			SigObj sigObj = sigCtl.signature();
			if (sigObj.isCaptured()) {
				sigObj.extraData("AdditionalData",
						"C# Wizard test: Additional data");
				String filename = "sig.png";
				int flags = SigObj.outputFilename | SigObj.color32BPP
						| SigObj.encodeData;
				sigObj.renderBitmap(filename, 200, 150, "image/png", 0.5f,
						0xff0000, 0xffffff, 0.0f, 0.0f, flags);
				paintSignature(filename);
				closeWizard();
			}
		}

		private void scriptCancelled() {
			textArea.append("scriptCancelled\n");
			closeWizard();
		}

		private void closeWizard() {
			textArea.append("closeWizard\n");
			scriptIsRunning = false;
			wizCtl.reset();
			wizCtl.display();
			wizCtl.padDisconnect();
			// wizCtl.setEventHandler(null);
		}

		private void paintSignature(String fileName) {
			try {
				signatureImage = ImageIO.read(new File(fileName));
				drawPanel.repaint();

			} catch (IOException e) {
				System.out.println(e.toString());
			}
		}

		protected void releaseControl() {
			wizCtl.reset();
			wizCtl.display();
			wizCtl.padDisconnect();
		}

	}

}

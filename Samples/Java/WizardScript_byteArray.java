/*
  WizardScript_byteArray
  Runs a Wizard script to capture a signature and create encoded image file sig.png
  Uses a byte array for button image upload
  
  Copyright (c) 2015 Wacom GmbH. All rights reserved.
  
 */


import com.florentis.signature.*;

import javax.imageio.ImageIO;
import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.font.FontRenderContext;
import java.awt.font.GlyphVector;
import java.awt.geom.Rectangle2D;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;

class WizardScript_byteArray implements WizCtl.WizCtlEvents {

	// static data
	static WizCtl wizCtl;
	static SigCtl sigCtl;
	static SigObj sigObj;
	static boolean ScriptIsRunning = false; // script run status

	private static void print(String s) {
		System.out.println(s);
	}

	private static void Error(String s) {
		System.out.println("Error: " + s);
	}

	private static void Exception(String s) {
		System.out.println("Exception: " + s);
	}

	private static void wizardScriptControl(String event) {
		try {
			// print("WizardScriptControl: " + event);
			// switch(event)
			if (event.compareToIgnoreCase("LOAD") == 0) {
				// case LOAD: // html page loaded
				print("Create controls...");
				sigCtl = new SigCtl();
        sigCtl.licence("<<license>>");
        
				wizCtl = new WizCtl();
        wizCtl.licence("<<license>>");
				wizardScriptControl("START_STOP");
			} else if (event.compareToIgnoreCase("START_STOP") == 0) {
				// case START_STOP:
				if (ScriptIsRunning) {
					wizardScriptControl("STOP");
					return;
				}
				// else start
				// initialise Pad
				boolean rc = wizCtl.padConnect();
				if (rc != true) {
					print("Unable to make connection to the Pad");
					wizCtl.reset();
				} else {
					print("Pad detected: " + wizCtl.padWidth() + " x "
							+ wizCtl.padHeight());
					ScriptIsRunning = true;
					Step1();
				}
			} else if (event.compareToIgnoreCase("STOP") == 0) {
				// case STOP: // UI button event
				if (!ScriptIsRunning) {
					print("Script not running");
					return;
				}
				ScriptIsRunning = false;
				// document.getElementById("btnStartStopWizard").value =
				// "Start Wizard";
				// ShowWizardCtl(false,0);
				wizCtl.reset();
				wizCtl.display(); // clear display
				wizCtl.padDisconnect();
				print("Pad disconnected");
				System.exit(0);
			}

			else if (event.compareToIgnoreCase("SCRIPT_COMPLETED") == 0) {
				// case SCRIPT_COMPLETED:
				print("Script completed");
				String filename = "sig.png";
				sigObj = sigCtl.signature();
				sigObj.extraData("AdditionalData",
						"WizardScript.java Additional Data");
				int flags = SigObj.outputFilename | SigObj.color32BPP
						| SigObj.encodeData;
				sigObj.renderBitmap(filename, 300, 150, "image/png", 0.5f,
						0xff0000, 0xffffff, 0.0f, 0.0f, flags);
				print("Created Signature image file: " + filename);
				wizardScriptControl("STOP");
			}

			else if (event.compareToIgnoreCase("SCRIPT_CANCELLED") == 0) {
				// case SCRIPT_CANCELLED:
				print("Script cancelled");
				wizardScriptControl("STOP");
			} else {
				// default:
				Error("WizardScriptControl('" + event + "'):  not recognised");
			}
		} catch (Exception ex) {
			Exception("WizardScriptControl('" + event + "'): " + ex);
		}
	}

	// == PadEventHandler
	// Java has a single event handler - use a lookup for the script
	// setEventHandler
	static String StepHandler; // script event handler set for each step

	private static void setEventHandler(String handler) {
		StepHandler = handler;
	}

	public boolean onPadEvent(WizCtl ctl, String id, Object o) {
		// print("onPadEvent: " + id);
		if (StepHandler.compareToIgnoreCase("Step1_Handler") == 0) {
			Step1_Handler(ctl, id, o);
		} else if (StepHandler.compareToIgnoreCase("Step2_Handler") == 0) {
			Step2_Handler(ctl, id, o);
		} else if (StepHandler.compareToIgnoreCase("Disabled") == 0) {
		} else {
			Error("Unexpected StepHandler: " + StepHandler);
		}
		return true;
	}

	// == StepControl
	private static void Step1() {
		try {
			int fsText = (wizCtl.padHeight() > 300) ? 16 : 8;
			int fsButton = (wizCtl.padHeight() > 300) ? 55 : 8;
			int btnWidth = 275;

			wizCtl.reset();
			setFont("Verdana", fsText, false);

			wizCtl.addObject(WizCtl.objectText, "txt", "centre", "middle",
					"Press NEXT to continue", null);

			// generate a button as image.
			Font font = new Font("Courier New", Font.PLAIN, fsButton);
			String message = "Cancel";
			byte[] imageBytes = generateButton(message, font);
			wizCtl.addObject(WizCtl.objectImage, "Cancel", "left", "bottom",
					imageBytes, null);

			message = "Next";
			imageBytes = generateButton(message, font);
			wizCtl.addObject(WizCtl.objectImage, "Next", "right", "bottom",
					imageBytes, null);

			wizCtl.display();

			setEventHandler("Step1_Handler");
		} catch (Exception ex) {
			Exception("Step1() " + ex);
		}
	}

	private static void Step1_Handler(WizCtl ctl, String id, Object oType) {
		if (id.compareToIgnoreCase("Next") == 0) {
			Step2();
		} else if (id.compareToIgnoreCase("Cancel") == 0) {
			print("Cancel");
			wizardScriptControl("SCRIPT_CANCELLED");
		} else {
			Error("Unexpected Step1 event: " + id);
		}
	}

	private static void Step2() {
		try {
			int fsText = (wizCtl.padHeight() > 300) ? 16 : 8;
			int fsButton = (wizCtl.padHeight() > 300) ? 22 : 8;
			int fsDottedLine = (wizCtl.padHeight() > 300) ? 32 : 16;
			int btnWidth = 5 * fsButton;
			int y = 0;

			wizCtl.reset();
			setFont("Verdana", fsText, false);
			y = 2 * fsText;
			wizCtl.addObject(WizCtl.objectText, "txt", "center", y,
					"Please sign below", null);

			setFont("Verdana", fsDottedLine, false);
			String dottedLine = "X..........................";
			dottedLine += (wizCtl.padHeight() > 300) ? "........." : "";
			y = wizCtl.padHeight() - 7 * fsButton;
			wizCtl.addObject(WizCtl.objectText, "txt", "centre", y, dottedLine,
					null);

			setFont("Verdana", fsText, false);
			SigObj sigObj = sigCtl.signature();
			wizCtl.addObject(WizCtl.objectSignature, "Sig", 0, 0, sigObj, null);
			y = wizCtl.padHeight() - (5 * fsButton);
			wizCtl.addObject(WizCtl.objectText, "who", "right", y, "J Smith",
					null);
			y += 2 * fsText;
			wizCtl.addObject(WizCtl.objectText, "why", "right", y,
					"I certify that the information is correct", null);

			setFont("Verdana", fsButton, false);
			wizCtl.addObject(WizCtl.objectButton, "Cancel", "left", "bottom",
					"Back", btnWidth);
			wizCtl.addObject(WizCtl.objectButton, "Clear", "center", "bottom",
					"Clear", btnWidth);
			wizCtl.addObject(WizCtl.objectButton, "OK", "right", "bottom",
					"OK", btnWidth);

			wizCtl.display();
			setEventHandler("Step2_Handler");
		} catch (Exception ex) {
			Exception("Step2() " + ex);
		}
	}

	private static void Step2_Handler(WizCtl ctl, String id, Object oType) {

		// switch(Id) {
		if (id.compareToIgnoreCase("OK") == 0) {
			// case "OK":
			wizardScriptControl("SCRIPT_COMPLETED");
		} else if (id.compareToIgnoreCase("Clear") == 0) {
			// case "Clear":
		} else if (id.compareToIgnoreCase("Cancel") == 0) {
			// case "Cancel": -- changed to 'Back'
			Step1();
			// wizardScriptControl("SCRIPT_CANCELLED");
		} else {
			// default:
			Error("Unexpected Step2 event: " + id);
		}
	}

	private static void setFont(String name, double size, boolean bold) {
		WizCtl.Font ff = new WizCtl.Font();
		ff.name = name != null ? name : "Verdana";
		ff.size = size != 0.0 ? size : 10.0;
		ff.bold = bold;
		wizCtl.setFont(ff);
	}

	// The constructor: class WizardScript implements WizCtl.WizCtlEvents
	public WizardScript_byteArray() {
		wizardScriptControl("LOAD");
		wizCtl.setEventHandler(this);
	}

	public static void main(String args[]) {
		WizardScript_byteArray ws = new WizardScript_byteArray();
		JFrame frame = new JFrame("Wizard Script");
		frame.setLocation(500, 500);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

		JPanel panel = new JPanel(new GridLayout(0, 1));
		JButton btnQuit = new JButton("Stop the Script");
		panel.add(new JLabel(""));
		panel.add(new JLabel(
				"    Click the button below to stop the Wizard script   ",
				JLabel.CENTER));
		panel.add(new JLabel(""));
		panel.add(btnQuit);
		panel.add(new JLabel(""));

		frame.add(panel);
		frame.pack();
		frame.setVisible(true);

		btnQuit.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				print("Button pressed");
				wizardScriptControl("STOP");
			}
		});
		try {
			ws.wizCtl.processEvents(); // wait for input from the tablet
		} catch (java.lang.InterruptedException ex) {
			Exception("InterruptedException: " + ex);
		}
	}

	private static byte[] generateButton(String message, Font font) {

		byte[] imageBytes = null;

		// a first BufferedImage to get a graphics context
		// it's necessary in order to get the font dimensions.
		BufferedImage bi = new BufferedImage(200, 200,
				BufferedImage.TYPE_INT_ARGB);

		// get the font dimensions.
		Graphics2D ig2 = bi.createGraphics();
		ig2.setFont(font);
		FontMetrics fontMetrics = ig2.getFontMetrics();
		FontRenderContext fr = ig2.getFontRenderContext();
		GlyphVector gv = font.createGlyphVector(fr, "5");
		Rectangle2D bounds = gv.getGlyphMetrics(0).getBounds2D();
		int height = (int) bounds.getHeight();
		int width = fontMetrics.stringWidth(message);
		// the margin is the space between the borders and the text.
		int margin = height;

		// new BufferedImage in which we are going to paint.
		// The dimensions are the same that the font plus the margin plus
		// one pixel on the right to show the line correctly and 10 on the
		// bottom
		// to separate the button a bit from the bottom of the screen.
		BufferedImage bf = new BufferedImage(width + margin + 1, height
				+ margin + 10, BufferedImage.TYPE_INT_ARGB);

		Graphics2D g2d = bf.createGraphics();
		g2d.setPaint(Color.black);
		g2d.setFont(font);

		g2d.drawString(message, margin / 2, height + (margin / 2));
		g2d.drawRect(0, 0, width + margin, height + margin);

		try {

			// generate a byte array from the BufferedImage.
			ByteArrayOutputStream baos = new ByteArrayOutputStream();
			ImageIO.write(bf, "png", baos);
			baos.flush();
			imageBytes = baos.toByteArray();
			baos.close();

		} catch (IOException e) {
		}

		return imageBytes;

	}
}
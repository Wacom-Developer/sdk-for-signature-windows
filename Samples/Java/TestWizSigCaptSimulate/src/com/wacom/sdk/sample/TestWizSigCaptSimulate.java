/*************************************************************************
  TestWizSigCaptSimulate.java
   
  Java Signature Capture using Wizard script

  The project displays a form with a button to start signature capture using the Wizard script
  The captured signature is encoded in an image file which is displayed on the form
  The form includes buttons which simulate the operation of the buttons on the pad
  
  Copyright (c) 2015 Wacom GmbH. All rights reserved.
  
***************************************************************************/
package com.wacom.sdk.sample;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.EventQueue;
import java.awt.Graphics;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;
import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.UIManager;
import javax.swing.border.LineBorder;
import javax.swing.border.TitledBorder;

import com.florentis.signature.SigCtl;
import com.florentis.signature.SigObj;
import com.florentis.signature.WizCtl;

public class TestWizSigCaptSimulate
{
	
	private enum STATE { STEP1, STEP2, NEXT, CANCEL, CLEARSCREEN, SAVE, QUIT };
	
	
	private STATE	            t_state;
	private static final String	START_LABEL	= "Start Wizard";
	private static final String	STOP_LABEL	= "Stop Wizard";
	private JFrame	            frmWizardScript;
	private JTextArea	          textArea;
	JButton	                    btnStartWizard;
	private BufferedImage	      signatureImage;
	private JPanel	            drawPanel;
	private JButton	            btnCancel, btnNext, btnCancel2, btnClear, btnOk;
	private Thread	            thread;
	private SigCtl              sigCtl;
	private SigObj		          sigObj;
	private String	            model;
	private WizCtl.Font	        textFont;
	private WizCtl.Font	        buttonFont;
	private WizCtl.Font	        sigLineFont;
	private int	                textLs;
	private int	                buttonWidth;


	private void dbgPrint(String s)
	{
		if (textArea != null) {
			  System.out.println(s);
		}
	}



	public static void main(String[] args)
	{
		EventQueue.invokeLater(new Runnable()
		{
			public void run()
			{
				TestWizSigCaptSimulate window = new TestWizSigCaptSimulate();
				window.frmWizardScript.setVisible(true);
			}
		});
	}



	private TestWizSigCaptSimulate()
	{
		initialize();
	}



	private void wizCtl_onPadEvent(String id, Object type)
	{
		dbgPrint("wizCtl_onPadEvent()");
		switch (t_state) {
			case STEP1: 
				if (id.equals("Next"))
					step2();
				else if (id.equals("Cancel"))
					stop();
				break;
			case STEP2:	
			case CLEARSCREEN:
			case SAVE:	
				if (id.equals("Ok"))
					scriptCompleted();
				else if (id.equals("Cancel"))
					stop();
				break;

		}		
	}
	
	private void scriptCompleted()
	{
		textArea.append("scriptCompleted\n");
		SigObj sigObj = sigCtl.signature();
		if (sigObj.isCaptured())
		{
			sigObj.extraData("AdditionalData", "Java Wizard test: Additional data");
			String filename = "sig1.png";
			int flags = SigObj.outputFilename | SigObj.color32BPP | SigObj.encodeData;
			sigObj.renderBitmap(filename, 200, 150, "image/png", 0.5f, 0xff0000, 0xffffff, 0.0f, 0.0f, flags);
			paintSignature(filename);
			stop();
		}
	}	

	private void paintSignature(String fileName)
	{
		try
		{
			signatureImage = ImageIO.read(new File(fileName));
			drawPanel.repaint();
		} catch (IOException e)
		{
			System.out.println(e.toString());
		}
	}

	private void t_run()
	{
		dbgPrint("t_run()");
		WizCtl wizCtl = new WizCtl();
    wizCtl.licence("<<license>>");
		wizCtl.setEventHandler(new WizCtl.WizCtlEvents()
		{
			public boolean onPadEvent(WizCtl ctl, final String id, final Object type)
			{
				dbgPrint("t:onPadEvent()");
				EventQueue.invokeLater(new Runnable()
				{
					public void run()
					{
						wizCtl_onPadEvent(id, type);
					}
				});
				return true;
			}
		});
		sigCtl = new SigCtl();
    sigCtl.licence("<<license>>");
		sigObj = sigCtl.signature();
		wizCtl.padConnect();
		
		textArea.append("Pad detected " + wizCtl.padWidth() + " x " + wizCtl.padHeight() + "\n");
		if (wizCtl.padHeight() > 100)
		{
			textArea.append("STU-500\n");
			pad500();
		} else
		{
			textArea.append("STU-300\n");
			pad300();
		}		
		
		t_loop(wizCtl);
		wizCtl.padDisconnect();
	}



	private void setState(STATE state)
	{
		dbgPrint("setState() sync thread");
		synchronized (thread)
		{
			dbgPrint("setState() thread locked");
			t_state = state;
			dbgPrint("setState() thread.interrupt()");
			thread.interrupt();
		}
		dbgPrint("setState() thread unlocked");
	}



	private void t_loop(WizCtl wizCtl)
	{
		dbgPrint("t_loop()");
		
		STATE state;
		
		dbgPrint("t_loop: init sync thread...");
		synchronized (thread)
		{
			dbgPrint("t_loop: init thread locked");
			if (t_state == null) {
				try
				{
					dbgPrint("t_loop: init thread wait");
				
					thread.wait();
				} catch (InterruptedException ex)
				{
				}
			}	
			dbgPrint("t_loop: init t_state retrieved");
			state = t_state;
		}
		dbgPrint("t_loop: init thread unlocked");
		
		b: for (;;)
		{
			dbgPrint("t_loop: loop");
			try {
				switch (state) {
					case QUIT: t_quit(wizCtl);
					textArea.append("quit wizard\n");
					break b;
					case STEP1: t_step1(wizCtl);
					textArea.append("load step1\n");
					break;
					case STEP2: t_step2(wizCtl);
					textArea.append("load step2\n");
					break;
					case CLEARSCREEN: wizCtl.fireClick("Clear");
					textArea.append("Clear screen\n"); 
					break;
					case SAVE: wizCtl.fireClick("Ok");
					textArea.append("Save signature\n");
					break;				                  
				}
			} catch (Exception e) 
			{
				dbgPrint("exception captured");
			}
			
			try
			{
				dbgPrint("t_loop: wizCtl.display()");
				wizCtl.display();
				
				dbgPrint("t_loop: wizCtl.processEvents()");
				wizCtl.processEvents();
				dbgPrint("t_loop: wizCtl.processEvents() completed");
			} catch (Exception ex)
			{
				dbgPrint("t_loop: wizCtl exception");
			}
			
			dbgPrint("t_loop: sync thread...");
			synchronized (thread)
			{
				dbgPrint("t_loop: thread locked");
				dbgPrint("t_loop: t_state retrieved");
				state = t_state;
			}
			dbgPrint("t_loop: thread unlocked");
		}
		
		dbgPrint("t_loop: quit");
	}



	private void step1()
	{
		btnCancel.setEnabled(true);
		btnNext.setEnabled(true);
		btnCancel2.setEnabled(false);
		btnClear.setEnabled(false);
		btnOk.setEnabled(false);
		setState(STATE.STEP1);
	}



	private void t_step1(WizCtl wizCtl)
	{
		wizCtl.reset();
		// insert message
		wizCtl.setFont(textFont);
		wizCtl.addObject(WizCtl.objectText, "txt", "centre", "middle", "Please NEXT to continue", null);
		// insert the buttons
		wizCtl.setFont(buttonFont);
		wizCtl.addObject(WizCtl.objectButton, "Cancel", "left", "bottom", "Cancel", buttonWidth);
		wizCtl.addObject(WizCtl.objectButton, "Next", "right", "bottom", "Next", buttonWidth);
		wizCtl.display();
	}



	private void step2()
	{
		btnCancel.setEnabled(false);
		btnNext.setEnabled(false);
		btnCancel2.setEnabled(true);
		btnClear.setEnabled(true);
		btnOk.setEnabled(true);
		setState(STATE.STEP2);
	}



	private void t_step2(WizCtl wizCtl)
	{
		int x, y = 0;
		wizCtl.reset();
		// insert message
		wizCtl.setFont(textFont);
		wizCtl.addObject(WizCtl.objectText, "txt", "centre", 10, "Please sign below...", null);
		// insert a signature line
		wizCtl.setFont(sigLineFont);
		y = (int) (wizCtl.padHeight() * 0.6);
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
		if (model == "STU-300")
		{
			xmargin = 5;
			ymargin = 0;
		}
		y = (int) (wizCtl.padHeight() - textLs - ymargin);
		x = xmargin;
		wizCtl.addObject(WizCtl.objectButton, "Cancel", x, y, "Cancel", buttonWidth);
		wizCtl.addObject(WizCtl.objectButton, "Clear", "center", y, "Clear", buttonWidth);
		x = wizCtl.padWidth() - buttonWidth - xmargin;
		wizCtl.addObject(WizCtl.objectButton, "Ok", x, y, "OK", buttonWidth);
		wizCtl.display(); 
	}



	void t_quit(WizCtl wizCtl)
	{
		wizCtl.reset();
		wizCtl.display();
	}



	void quit()
	{
		btnStartWizard.setText(START_LABEL);
		btnCancel.setEnabled(false);
		btnNext.setEnabled(false);
		btnCancel2.setEnabled(false);
		btnClear.setEnabled(false);
		btnOk.setEnabled(false);
	}



	private void stop()
	{
		quit();
		setState(STATE.QUIT);
		try
		{
			thread.join();
		} catch (InterruptedException ex)
		{
		}
		thread = null;
		t_state = null;
	}



	private void actionStartStop(ActionEvent e)
	{
		dbgPrint("actionStartStop()");
		if (btnStartWizard.getText().equals(START_LABEL))
		{
			thread = new Thread(new Runnable()
			{
				public void run()
				{
					t_run();
				}
			});
			thread.start();		
			btnStartWizard.setText(STOP_LABEL);
			step1();
		} else
		{
			stop();
		}
	}


	private void pad500()
	{
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



	private void pad300()
	{
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




	@SuppressWarnings("serial")
  private void initialize()
	{
		try
		{
			UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
		} catch (Exception e)
		{
			e.printStackTrace();
		}
		frmWizardScript = new JFrame();
		frmWizardScript.setBackground(Color.LIGHT_GRAY);
		frmWizardScript.setTitle("Wizard Script - Simulate");
		frmWizardScript.setBounds(100, 100, 600, 400);
		frmWizardScript.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frmWizardScript.getContentPane().setLayout(new BoxLayout(frmWizardScript.getContentPane(), BoxLayout.Y_AXIS));
		JPanel panel = new JPanel();
		panel.setBackground(Color.LIGHT_GRAY);
		frmWizardScript.getContentPane().add(panel);
		JPanel panel_1 = new JPanel();
		panel_1.setBackground(Color.LIGHT_GRAY);
		panel_1.setBorder(new TitledBorder(new LineBorder(new Color(0, 0, 0)), "Signature", TitledBorder.LEADING, TitledBorder.TOP, null, Color.BLACK));
		panel_1.setPreferredSize(new Dimension(200, 150));
		panel.add(panel_1);
		panel_1.setLayout(new BoxLayout(panel_1, BoxLayout.X_AXIS));
		drawPanel = new JPanel()
		{
			@Override
			public void paintComponent(Graphics g)
			{
				super.paintComponent(g);
				if (signatureImage != null)
				{
					g.drawImage(signatureImage, 0, 0, null);
				}
			}
		};
		panel_1.add(drawPanel);
		JPanel panel_3 = new JPanel();
		panel.add(panel_3);
		panel_3.setBackground(Color.LIGHT_GRAY);
		btnStartWizard = new JButton(START_LABEL);
		btnStartWizard.addActionListener(new ActionListener()
		{
			public void actionPerformed(ActionEvent e)
			{
				actionStartStop(e);
			}
		});
		panel_3.add(btnStartWizard);
		JPanel panel_4 = new JPanel();
		panel_4.setBackground(Color.LIGHT_GRAY);
		panel_4.setBorder(new TitledBorder(new LineBorder(new Color(0, 0, 0)), "Wizard Control", TitledBorder.LEADING, TitledBorder.TOP, null, null));
		frmWizardScript.getContentPane().add(panel_4);
		panel_4.setLayout(new BoxLayout(panel_4, BoxLayout.Y_AXIS));
		JPanel panel_5 = new JPanel();
		panel_5.setBackground(Color.LIGHT_GRAY);
		panel_4.add(panel_5);
		JLabel lblWizardStepControls = new JLabel("Wizard Step1 controls:");
		panel_5.add(lblWizardStepControls);
		btnCancel = new JButton("Cancel");
		btnCancel.addActionListener(new ActionListener()
		{
			public void actionPerformed(ActionEvent e)
			{
				wizCtl_onPadEvent("Cancel", null);
			}
		});
		btnCancel.setEnabled(false);
		panel_5.add(btnCancel);
		btnNext = new JButton("Next");
		btnNext.addActionListener(new ActionListener()
		{
			public void actionPerformed(ActionEvent e)
			{
				wizCtl_onPadEvent("Next", null);
			}
		});
		btnNext.setEnabled(false);
		panel_5.add(btnNext);
		JPanel panel_6 = new JPanel();
		panel_6.setBackground(Color.LIGHT_GRAY);
		panel_4.add(panel_6);
		JLabel lblWizardStepControls_1 = new JLabel("Wizard Step2 controls:");
		panel_6.add(lblWizardStepControls_1);
		btnCancel2 = new JButton("Cancel");
		btnCancel2.setEnabled(false);
		btnCancel2.addActionListener(new ActionListener()
		{
			public void actionPerformed(ActionEvent e)
			{
				wizCtl_onPadEvent("Cancel", null);
			}
		});
		panel_6.add(btnCancel2);
		btnClear = new JButton("Clear");
		btnClear.addActionListener(new ActionListener()
		{
			public void actionPerformed(ActionEvent e)
			{
				setState(STATE.CLEARSCREEN);
			}
		});
		btnClear.setEnabled(false);
		panel_6.add(btnClear);
		btnOk = new JButton("Ok");
		btnOk.addActionListener(new ActionListener()
		{
			public void actionPerformed(ActionEvent e)
			{
				setState(STATE.SAVE);
			}
		});
		btnOk.setEnabled(false);
		panel_6.add(btnOk);
		JPanel panel_7 = new JPanel();
		panel_7.setBackground(Color.LIGHT_GRAY);
		frmWizardScript.getContentPane().add(panel_7);
		textArea = new JTextArea();
		textArea.setColumns(50);
		textArea.setRows(5);
		JScrollPane scrollPane = new JScrollPane(textArea);
		panel_7.add(scrollPane);
	}
}

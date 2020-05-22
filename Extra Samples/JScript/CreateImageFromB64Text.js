/*
  CreateImageFromB64Text.js
  Demonstrates the transfer of browser SigText to an image file and also runs an integrity check.
  Signature image is output to "sig.png" by default - an alternative name can be supplied as an argument.
  
  Copyright (c) 2019 Wacom. All rights reserved.
*/
function print( txt ) {
  WScript.Echo(txt);
}
main();
function main() {
  filename = "sig.png";
  args = WScript.Arguments;
  if(args.Count() > 0 )
    filename=args(0);
  sigObj = new ActiveXObject("Florentis.SigObj");
  sigObj.SigText = 
  "RlPPtBQFCgEFAL9PoI0GAgAHCgEFAM87oI0GAgEJCAEFAACQTgQACwfIAQABAQEAAwkC9AIBCgECXIAGiQMC9ALhFwgIgAPoBgsOGSIoMDg8Pjw5NzEtJyEZEw0FAPr18wHv+u7x8PTz9vUC9wH59vz+AgUKDRIWGRsdAR//HhwBG/kYFxUTEQ8ODQEM+w8RExgbHwEh8B8eGhUPCQT++fTv6+nm4+LgAd/h3t3f4OHk5+vw9vr+AwYLDRIWGR4iJigpKiknJiMiHx0BG/0YFxUUAREADwEO8wwLCQYC/vn18vDu7O3sAu3+7u3vAu4A7QHu0vL2/AQOGCEsNj5DRkhJR0M9NzEsJR4YEg0HA/348+3m39bPx8G+vb/DydLd5u72AQD7DhEXHCAkAyj/JSQBIgEg7B4cGRYRDQcB+/fw7enk4t7d2tjX1AHTiNXW2+Tt+wscL0NUY252eXhzaV9RRjYqHxUNAAX79vTx7uzt8PP5/AMJDhYaHSImJyopKCQhGxYRCwQA8+/r5eHf4OTr9AEQHi08R1BXWFdSSj8yJhoNAPzy7ern5ent9P4KGik5SFVibHJ2eHZ0b2hgWU9JOjUsJBsIhgMC9AL+HggI/QLYDQUAAgUA/fny6NzQw7itpZ+cm5yepKivtb7Hz9rh6/P7BAwZIi84QEgBTPFKR0E9NjEqIxwWDgkD//v6Affz+Pr7AAYOGSAsNkFJUFMBVMBTT01KRkNAPTk1LykjHBQMA/nt59/a19TW2eDk6e7y9/z+AgQHCAkIBQP/+/fx7ejk39rV0MzGxL27tbGsp6KblQGU6Ziaoqm0wMrS2OLp8Pf+Bw8aIy05Q01VWAFZ+ldQS0M6NDMBL/0xNDc7Aj70OTQtJh8WDgYA+fPu6gLo+unt8PP2+foBAP3y+vj1AfIB797s6+jm4t7Z1MzIwLiwqaSjpaartL/L1eDq9QALFiEsOENOWgFgjl9ZUkM1IhEB9uri2tbX2N7k6/H4ABEZJS89R1FTUUxFPjQrIBgPB/zy597TzMbFys/Y4eoA/BEdKDQ/R0pIQjktHQv67N3Sx8DBxMvV3uv4ABoeKDA4PDs3LycfFQf88ebb0sfBvr2+w8fN1Njl4/P7BA0ECQL0AgEKAQJcgA2UAgL0AuIBBwiLAv6OjAQIEAgQAN//QD/AQAEAgAICBgQX8DA4MBBQIH/AQICAewEAAQAB/wwAHAQAEBAf4EAhAIEA/gD/AAP//AP8CAAQEAAAQEAAAgEGAfQH/Af8EAAAEEAAAECAAAECAAAEEAAP8GAfQEAAQAEAgAAEA/wABBAAH/Bf3z//v/+AAgCAAAICFAP/+AhQD+A/4oAAAIEA+AIAAgACBAAICCAPwCAAIEAAgPwCAAIAAQIB/Af8CAAP8GAAAECAegEAAQABAAECAAAEEAfgH/AQwAA/wYB2/wAB/wH/AAEAAQAEA/wABAgH0BAAEAAgIACCgIIAA/4AABf4EAAAIEAEgIACAgLgA+blFR0lKAwIAQUA/wMAAABPBQTqxA98FAgBBAC/TwDPOx0dHAYA/x2aDGMGiFH7X2npBgBQVsAAAQYAUFbAAAgcKShNaWNyb3NvZnQ7J1dpbmRvd3MgOC4xJzs7OzYuMy45NjAwLjE3NDE1GhoZU1RVOydTVFUtNTAwJzsxLjAuMDsxMjM0NRsWFTAwNjM7d2l6YXJkO3dhY29tO1NUVRgHu6fAvgU8AFQEAzE1NxcIB0ogU21pdGgWKilJIGNlcnRpZnkgdGhhdCB0aGUgaW5mb3JtYXRpb24gaXMgY29ycmVjdA==";
  
  result = sigObj.CheckIntegrity();
  print("result: " + result);
  
  flags = 0x481000; //SigObj.outputFilename | SigObj.color32BPP | SigObj.encodeData
  rc = sigObj.RenderBitmap(filename, 300, 150, "image/png", 0.5, 0xff0000, 0xffffff, 0.0, 0.0, flags );
  print("Created Signature image file: " + filename);
}

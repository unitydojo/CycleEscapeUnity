using UnityEngine;

public static class HexColor
{
    public static Color ColorFromHex(string hexString) {
        float red = HexToFloatNormalized(hexString.Substring(0, 2));
        float green = HexToFloatNormalized(hexString.Substring(2, 2));
        float blue = HexToFloatNormalized(hexString.Substring(4, 2));
        float alpha = 1f;
        if (hexString.Length >= 8) {
            alpha = HexToFloatNormalized(hexString.Substring(6, 2));
        }
        return new Color(red, green, blue, alpha);
    }
    
    private static int HexToDec(string hex) {
        return System.Convert.ToInt32(hex, 16);;
    }
    private static float HexToFloatNormalized(string hex) {
        return HexToDec(hex) / 255f;
    }
   
}

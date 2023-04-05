using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Сreational.Builder
{
    abstract class TextConverterBuilder
    {
        public abstract void ConvertCharacter(string character);
        public abstract void ConvertFontChange(string font);
        public abstract void ConvertParagraph();
    }
    class ASCIIConverter : TextConverterBuilder
    {
        public override void ConvertCharacter(string character)
        {
            GetASCIIText();
            Console.WriteLine("Символы сконвертированны." + character);
        }
        public override void ConvertFontChange(string font) { }
        public override void ConvertParagraph() { }
        private void GetASCIIText()
        {
            Console.WriteLine("Получен текст.");
        }
    }
    class TeXConverter : TextConverterBuilder
    {
        public override void ConvertCharacter(string character)
        {
            GetTeXText();
            Console.WriteLine("Символы сконвертированны." + character);
        }
        public override void ConvertFontChange(string font)
        {
            GetTeXText();
            Console.WriteLine("Изменен шрифт текста.");
        }
        public override void ConvertParagraph()
        {
            GetTeXText();
            Console.WriteLine("Изменен формат параграфа.");
        }
        private void GetTeXText()
        {
            Console.WriteLine("Получен текст.");
        }
    }
    class TextWidgetConverter : TextConverterBuilder
    {
        public override void ConvertCharacter(string character)
        {
            GetTextWidget();
            Console.WriteLine("Символы сконвертированны." + character);
        }
        public override void ConvertFontChange(string font)
        {
            GetTextWidget();
            Console.WriteLine("Изменен шрифт текста.");
        }
        public override void ConvertParagraph()
        {
            GetTextWidget();
            Console.WriteLine("Изменен формат параграфа.");
        }
        private void GetTextWidget()
        {
            Console.WriteLine("Получен текст.");
        }
    }
    class RTFReader
    {
        private TextConverterBuilder builder;
        public void ParseRTF()
        {
            builder = new TeXConverter();
            builder.ConvertCharacter("TeX");
        }
    }
}
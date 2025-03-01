using EcoStep.Application.Services.Interfaces;

namespace EcoStep.Application.Services.Classes;
using MailKit.Net.Smtp;
using MimeKit;
using System.IO;
using System.Threading.Tasks;

public class EmailService : IEmailService
{
    private readonly string _smtpServer = "smtp.gmail.com";
    private readonly int _smtpPort = 587;
    private readonly string _smtpUser = "jamirgutierrezdelcarpio@gmail.com";
    private readonly string _smtpPassword = "cnmo mkcr kium yofv";

    public async Task SendMailAsync(string deliverTo, string code)
    {
        var mensaje = new MimeMessage();
        mensaje.From.Add(new MailboxAddress("VanGo - Verificación", _smtpUser));
        mensaje.To.Add(new MailboxAddress("", deliverTo));
        mensaje.Subject = "VanGo - Código de Confirmación";

        var cuerpoHtml = $@"
            <html>
               <body>
    <table class=""m_-1342071583008771539row-1"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0""
        role=""presentation"" style=""box-sizing:border-box"">
        <tbody style=""box-sizing:border-box"">
            <tr style=""box-sizing:border-box"">
                <td style=""box-sizing:border-box"">
                    <table class=""m_-1342071583008771539row-content"" align=""center"" border=""0"" cellpadding=""0""
                        cellspacing=""0"" role=""presentation""
                        style=""box-sizing:border-box;border-radius:0;color:#000;width:600px;margin:0 auto"" width=""600"">
                        <tbody style=""box-sizing:border-box"">
                            <tr style=""box-sizing:border-box"">
                                <td class=""m_-1342071583008771539column m_-1342071583008771539column-1"" width=""100%""
                                    style=""box-sizing:border-box;font-weight:400;text-align:left;padding-bottom:24px;padding-top:24px;vertical-align:top;border-top:0;border-right:0;border-bottom:0;border-left:0""
                                    align=""left"" valign=""top"">
                                    <table class=""m_-1342071583008771539image_block"" width=""100%"" border=""0""
                                        cellpadding=""0"" cellspacing=""0"" role=""presentation""
                                        style=""box-sizing:border-box"">
                                        <tbody>
                                            <tr style=""box-sizing:border-box"">
                                                <td class=""m_-1342071583008771539pad""
                                                    style=""box-sizing:border-box;width:100%;padding-right:0;padding-left:0""
                                                    width=""100%"">
                                                    <div class=""m_-1342071583008771539alignment"" align=""left""
                                                        style=""box-sizing:border-box;line-height:10px"">
                                                        <div style=""box-sizing:border-box;max-width:70px""><a href=""""
                                                                style=""box-sizing:border-box;outline:none""
                                                                target=""_blank""
                                                                data-saferedirecturl=""""><img
                                                                    src=""https://res.cloudinary.com/dkhhufbkd/image/upload/v1740696299/Asset_19_gtv4hp.png""
                                                                    style=""box-sizing:border-box;display:block;height:auto;border:0;width:100%""
                                                                    width=""150"" alt=""VanGo""
                                                                    title=""VanGo"" height=""auto"" class=""CToWUd""
                                                                    data-bit=""iit""></a></div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>


            </tr>

            <tr style=""box-sizing:border-box"">
                <table class=""m_-1342071583008771539row-content m_-1342071583008771539stack"" align=""center"" border=""0""
                    cellpadding=""0"" cellspacing=""0"" role=""presentation""
                    style=""box-sizing:border-box;background-color:#fff;border-radius:0;color:#000;width:600px;margin:0 auto""
                    width=""600"" bgcolor=""#fff"">
                    <tbody style=""box-sizing:border-box"">
                        <tr style=""box-sizing:border-box"">
                            <td class=""m_-1342071583008771539column m_-1342071583008771539column-1"" width=""100%""
                                style=""box-sizing:border-box;font-weight:400;text-align:left;padding-bottom:24px;padding-left:24px;padding-right:24px;padding-top:24px;vertical-align:top;border-top:0;border-right:0;border-bottom:0;border-left:0""
                                align=""left"" valign=""top"">
                                <table class=""m_-1342071583008771539text_block"" width=""100%"" border=""0"" cellpadding=""0""
                                    cellspacing=""0"" role=""presentation""
                                    style=""box-sizing:border-box;word-break:break-word"">
                                    <tbody>
                                        <tr style=""box-sizing:border-box"">
                                            <td class=""m_-1342071583008771539pad""
                                                style=""box-sizing:border-box;padding-bottom:24px"">
                                                <div style=""box-sizing:border-box;font-family:Arial,sans-serif"">
                                                    <div
                                                        style=""box-sizing:border-box;font-size:12px;font-family:'Helvetica Neue',Helvetica,Arial,sans-serif;color:#2e3033;line-height:1.5"">
                                                        <p style=""box-sizing:border-box;line-height:inherit;margin:0"">
                                                            <span
                                                                style=""box-sizing:border-box;font-size:16px;color:#16191c"">Recibimos
                                                                una solicitud para verificar esta dirección de correo
                                                                electrónico.&nbsp;</span>
                                                        </p>
                                                        <p style=""box-sizing:border-box;line-height:inherit;margin:0"">
                                                            &nbsp;</p>
                                                        <p style=""box-sizing:border-box;line-height:inherit;margin:0"">
                                                            <span
                                                                style=""box-sizing:border-box;font-size:16px;color:#16191c"">Para
                                                                comenzar a utilizar su cuenta de VanGo verifique su
                                                                dirección de correo electrónico vinculada. Simplemente
                                                                ingrese este código en la ventana donde inició la
                                                                verificación del correo electrónico:</span></p>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation""
                                    style=""box-sizing:border-box"">
                                    <tbody>
                                        <tr style=""box-sizing:border-box"">
                                            <td class=""m_-1342071583008771539pad"" style=""box-sizing:border-box"">
                                                <div style=""box-sizing:border-box;font-family:'Helvetica Neue',Helvetica,Arial,sans-serif;text-align:center""
                                                    align=""center"">
                                                    <div
                                                        style=""box-sizing:border-box;padding:24px;background-color:#f5f5f5;border-radius:4px;text-align:left;line-height:24px;color:#16191c"">
                                                        <div
                                                            style=""box-sizing:border-box;font-size:20px;text-align:center;letter-spacing:5px;font-weight:700"">
                                                            {code}</div>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <table class=""m_-1342071583008771539text_block"" width=""100%"" border=""0"" cellpadding=""0""
                                    cellspacing=""0"" role=""presentation""
                                    style=""box-sizing:border-box;word-break:break-word"">
                                    <tbody>
                                        <tr style=""box-sizing:border-box"">
                                            <td class=""m_-1342071583008771539pad""
                                                style=""box-sizing:border-box;padding-top:40px"">
                                                <div style=""box-sizing:border-box;font-family:Arial,sans-serif"">
                                                    <div
                                                        style=""box-sizing:border-box;font-size:12px;font-family:'Helvetica Neue',Helvetica,Arial,sans-serif;color:#2e3033;line-height:1.5"">

                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <table class=""m_-1342071583008771539button_block m_-1342071583008771539block-4""
                                    width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation""
                                    style=""box-sizing:border-box"">
                                    <tbody>
                                        <tr style=""box-sizing:border-box"">

                                        </tr>
                                    </tbody>
                                </table>
                                <table class=""m_-1342071583008771539text_block m_-1342071583008771539block-5""
                                    width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation""
                                    style=""box-sizing:border-box;word-break:break-word"">
                                    <tbody>
                                        <tr style=""box-sizing:border-box"">
                                            <td class=""m_-1342071583008771539pad""
                                                style=""box-sizing:border-box;padding-bottom:40px"">
                                                <div style=""box-sizing:border-box;font-family:Arial,sans-serif"">
                                                    <div
                                                        style=""box-sizing:border-box;font-size:12px;font-family:'Helvetica Neue',Helvetica,Arial,sans-serif;color:#222e3a;line-height:1.5"">
                                                        <p
                                                            style=""box-sizing:border-box;line-height:inherit;margin:0;font-size:14px"">
                                                            <span
                                                                style=""box-sizing:border-box;color:#16191c;font-size:16px""><span
                                                                    style=""box-sizing:border-box"">Disfruta tu viaje,<br
                                                                        style=""box-sizing:border-box"">El equipo de
                                                                    VanGo</span></span>
                                                        </p>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </tr>

            <tr style=""box-sizing:border-box"">
                <td style=""box-sizing:border-box"">
                    <table class=""m_-1342071583008771539row-content m_-1342071583008771539stack"" align=""center""
                        border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation""
                        style=""box-sizing:border-box;background-color:#f5f5f5;border-radius:12px;color:#000;width:600px;margin:0 auto""
                        width=""600"" bgcolor=""#f5f5f5"">
                        <tbody style=""box-sizing:border-box"">
                            <tr style=""box-sizing:border-box"">
                                <td class=""m_-1342071583008771539column m_-1342071583008771539column-1"" width=""100%""
                                    style=""box-sizing:border-box;font-weight:400;text-align:left;padding-bottom:24px;padding-left:24px;padding-right:24px;padding-top:24px;vertical-align:top;border-top:0;border-right:0;border-bottom:0;border-left:0""
                                    align=""left"" valign=""top"">
                                    <table class=""m_-1342071583008771539text_block"" width=""100%"" border=""0""
                                        cellpadding=""0"" cellspacing=""0"" role=""presentation""
                                        style=""box-sizing:border-box;word-break:break-word"">
                                        <tbody>
                                            <tr style=""box-sizing:border-box"">
                                                <td class=""m_-1342071583008771539pad"" style=""box-sizing:border-box"">
                                                    <div style=""box-sizing:border-box;font-family:Arial,sans-serif"">
                                                        <div
                                                            style=""box-sizing:border-box;font-size:12px;font-family:'Helvetica Neue',Helvetica,Arial,sans-serif;color:#222e3a;line-height:1.5"">
                                                            <p
                                                                style=""box-sizing:border-box;line-height:inherit;margin:0"">
                                                                <span style=""box-sizing:border-box;font-size:14px""><span
                                                                        style=""box-sizing:border-box"">P.D. Si usted no
                                                                        solicitó que se
                                                                    </span>verifique<span
                                                                        style=""box-sizing:border-box"">&nbsp;su</span>&nbsp;cuenta,&nbsp;<span
                                                                        style=""box-sizing:border-box"">por favor ignore
                                                                        este mensaje.</span></span>
                                                            </p>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>

            <tr style=""box-sizing:border-box"">
                <td style=""box-sizing:border-box"">
                    <table class=""m_-1342071583008771539row-content m_-1342071583008771539stack"" align=""center""
                        border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation""
                        style=""box-sizing:border-box;color:#000;width:600px;margin:0 auto"" width=""600"">
                        <tbody style=""box-sizing:border-box"">
                            <tr style=""box-sizing:border-box"">
                                <td class=""m_-1342071583008771539column m_-1342071583008771539column-1"" width=""100%""
                                    style=""box-sizing:border-box;font-weight:400;text-align:left;padding-bottom:40px;padding-top:5px;vertical-align:top;border-top:0;border-right:0;border-bottom:0;border-left:0""
                                    align=""left"" valign=""top"">
                                    <div style=""box-sizing:border-box;height:24px;line-height:24px;font-size:1px""> 
                                    </div>
                                    <table class=""m_-1342071583008771539text_block"" width=""100%"" border=""0""
                                        cellpadding=""0"" cellspacing=""0"" role=""presentation""
                                        style=""box-sizing:border-box;word-break:break-word"">
                                        <tbody>
                                            <tr style=""box-sizing:border-box"">
                                                <td class=""m_-1342071583008771539pad"" style=""box-sizing:border-box"">
                                                    <div style=""box-sizing:border-box;font-family:Arial,sans-serif"">
                                                        <div
                                                            style=""box-sizing:border-box;font-size:12px;font-family:'Helvetica Neue',Helvetica,Arial,sans-serif;color:#fa3556;line-height:1.5"">
                                                            <p
                                                                style=""box-sizing:border-box;line-height:inherit;margin:0;text-align:left"">
                                                                <span style=""box-sizing:border-box;font-size:14px"">
                                                                </span>
                                                            </p>
                                                            <div></div>
                                                            <table bgcolor=""#ffffff"" cellpadding=""0"" cellspacing=""0""
                                                                role=""presentation""
                                                                style=""table-layout:fixed;vertical-align:top;min-width:320px;border-spacing:0;border-collapse:collapse;background-color:#ffffff;width:100%""
                                                                width=""100%"">
                                                                <tbody>
                                                                    <tr style=""vertical-align:top"" valign=""top"">
                                                                        <td style=""word-break:break-word;vertical-align:top""
                                                                            valign=""top"">
                                                                            <div style=""background-color:#ffffff"">
                                                                                <div
                                                                                    style=""min-width:320px;max-width:600px;word-wrap:break-word;word-break:break-word;margin:0 auto;background-color:transparent"">
                                                                                    <div
                                                                                        style=""border-collapse:collapse;display:table;width:100%;background-color:transparent"">
                                                                                        <div
                                                                                            style=""min-width:320px;max-width:600px;display:table-cell;vertical-align:top;width:600px"">
                                                                                            <div
                                                                                                style=""width:100%!important"">
                                                                                                <div
                                                                                                    style=""border:0px solid transparent;padding:24px 0 24px 0"">
                                                                                                    <hr
                                                                                                        style=""border:none;border-top:3px solid #16191c;margin:24px 0"">
                                                                                                    <img alt=""VanGo""
                                                                                                        src=""https://res.cloudinary.com/dkhhufbkd/image/upload/v1740696299/Asset_19_gtv4hp.png""
                                                                                                        style=""display:block;margin:24px 24px 24px 0;max-width:50px;height:auto""
                                                                                                        class=""CToWUd""
                                                                                                        data-bit=""iit"">
                                                                                                    <div
                                                                                                        style=""color:#2e3033;font-family:Helvetica Neue,Helvetica,Arial,sans-serif;line-height:1.5;padding:0px"">
                                                                                                        <div
                                                                                                            style=""line-height:1.5;font-size:12px;color:#555555;font-family:Helvetica Neue,Helvetica,Arial,sans-serif"">
                                                                                                            <p
                                                                                                                style=""margin:0;font-size:12px;line-height:1.5;word-break:break-word;text-align:left;margin-top:0;margin-bottom:0"">
                                                                                                                <span
                                                                                                                    style=""color:#2e3033""><span
                                                                                                                        style=""line-height:1.5""><span
                                                                                                                            style=""word-break:break-word"">Enviado
                                                                                                                            con
                                                                                                                            <img data-emoji=""❤️""
                                                                                                                                class=""an1""
                                                                                                                                alt=""❤️""
                                                                                                                                aria-label=""❤️""
                                                                                                                                draggable=""false""
                                                                                                                                src=""https://fonts.gstatic.com/s/e/notoemoji/16.0/1fa75/32.png""
                                                                                                                                loading=""lazy"">&nbsp;por
                                                                                                                            VanGo.<br>VanGo,

                                                                                                                            Galicia,
                                                                                                                            España
                                                                                                                        </span></span><br><br><span
                                                                                                                        style=""line-height:1.5""><span
                                                                                                                            style=""word-break:break-word"">Este
                                                                                                                            email
                                                                                                                            ha
                                                                                                                            sido
                                                                                                                            enviado
                                                                                                                            a
                                                                                                                            <a href=""mailto:{deliverTo}""
                                                                                                                                target=""_blank"">{deliverTo}</a>.</span></span></span><br><span
                                                                                                                    style=""font-size:12px;color:#2e3033"">¿Necesitas
                                                                                                                    ayuda?
                                                                                                                    <a href=""""
                                                                                                                        rel=""noopener""
                                                                                                                        style=""text-decoration:underline;color:#2e3033""
                                                                                                                        target=""_blank""
                                                                                                                        data-saferedirecturl="""">Centro
                                                                                                                        de
                                                                                                                        ayuda</a>.
                                                                                                                    Nuestro
                                                                                                                    Equipo
                                                                                                                    esta
                                                                                                                    disponible
                                                                                                                    24/7.</span>
                                                                                                            </p>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <div></div>
                                                            <p></p>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>





    

</body>
            </html>";

        var cuerpo = new TextPart("html") { Text = cuerpoHtml };

        //var adjunto = new MimePart("application", "pdf")
        //{
        //    Content = new MimeContent(File.OpenRead("ejemplo.pdf")),
        //    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
        //    ContentTransferEncoding = ContentEncoding.Base64,
        //    FileName = "code.pdf"
        //};

        var multipart = new Multipart("mixed")
        {
            cuerpo
            //adjunto
        };

        mensaje.Body = multipart;

        using (var cliente = new SmtpClient())
        {
            await cliente.ConnectAsync(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
            await cliente.AuthenticateAsync(_smtpUser, _smtpPassword);
            await cliente.SendAsync(mensaje);
            await cliente.DisconnectAsync(true);
        }
    }

    public async Task <string>  GenerateCode()
    {
        Random random = new Random();
        return random.Next(1000, 9999).ToString();
    }
}

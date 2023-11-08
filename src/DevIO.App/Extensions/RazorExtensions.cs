using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;

namespace DevIO.App.Extensions
{
    public static class RazorExtensions
    {
        public static string FormataDocumento(this RazorPage page, int tipoPessoa, string documento)
        {
            return tipoPessoa == 1 ? Convert.ToUInt64(documento).ToString(@"000\.000\.000\-00") : Convert.ToUInt64(documento).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string MarcarOpcao(this RazorPage page, int tipoPessoa, int valor)
        {
            return tipoPessoa == valor ? "checked" : "";
        }


        public static bool IfClaim(this RazorPage page, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidarClaimsUsuario(page.Context, claimName, claimValue);
        }

        public static string IfClaimShow(this RazorPage page, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidarClaimsUsuario(page.Context, claimName, claimValue) ? "" : "disabled";
        }

        public static IHtmlContent IfClaimShow(this IHtmlContent page, HttpContext context, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidarClaimsUsuario(context, claimName, claimValue) ? page : null;
        }

        public static string FormataTelefone(this RazorPage page, string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
            {
                return string.Empty;
            }

            
            if (telefone.Length == 10)
            {
                return string.Format("({0}) {1}-{2}",
                    telefone.Substring(0, 2),
                    telefone.Substring(2, 4),
                    telefone.Substring(6));
            }
           
            else if (telefone.Length == 11)
            {
                return string.Format("({0}) {1}-{2}",
                    telefone.Substring(0, 2),
                    telefone.Substring(2, 5),
                    telefone.Substring(7));
            }
            
            return telefone;
        }

    }
}
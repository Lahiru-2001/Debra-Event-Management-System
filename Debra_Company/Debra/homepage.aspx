<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="Debra.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        /* Home page styles */
section {
    padding: 0px 0; /* Section padding */
    display: flex;
    justify-content: center;
    align-items: center;
    text-align: center; /* Center text */
    flex-direction: column; /* Ensure column layout */
}

.img-fluid {
    max-width: 100%;
    height: auto;
    display: block;
    margin: 0 auto;
}

.container {
    max-width: 1200px;
    margin: 0 auto;
    top:10px;
    padding: 0 15px;
}

.row {
    display: flex;
    flex-wrap: wrap;
    margin: 0 -15px;
}

.col-12 {
    width: 100%;
    padding: 0 15px;
}

h2 {
    font-size: 2rem;
    color: #000;
    margin-bottom: 20px;
}

p {
    font-size: 1.125rem;
    color: #000;
    line-height: 1.6;
}

/* Media Queries */
@media (max-width: 992px) {
    h2 {
        font-size: 1.75rem;
    }

    p {
        font-size: 1rem;
    }
}

@media (max-width: 768px) {
    h2 {
        font-size: 1.5rem;
    }

    p {
        font-size: 0.875rem;
    }
}

@media (max-width: 576px) {
    h2 {
        font-size: 1.25rem;
    }

    p {
        font-size: 0.75rem;
    }
}
    </style>
    <section>
        <img src="images/eventscom_cover.jpeg"  class="img-fluid"/>

    </section>

     <section>
     
         <div class="container">
             <div class="row">
                  <div class="col-12">
                      <center>
                      <h2>What We Are</h2>
                      <p><b>Debra event management company Specializing in creating unforgettable events, Debra Event 
                          Management Company offers comprehensive services to plan, organize, and execute a wide range of events.
                          From corporate conferences to musical shows featuring the world's
                          top musicians and bands, we bring your vision to life with precision and creativity.</b></p>
                      </center>

 </div>
             </div>
         </div>

 

         <section>
             <img src="images/ctoykrzsmv.jpeg"   class="img-fluid"/>
</section>
 </section>

</asp:Content>

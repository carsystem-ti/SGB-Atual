﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SGB.tmkService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CarSystemPC", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class CarSystemPC : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PdVendaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContratoField;
        
        private System.Nullable<int> IdParcelaField;
        
        private System.Nullable<float> ValorField;
        
        private System.Nullable<float> ValorJurosField;
        
        private System.Nullable<float> ValorDescontoField;
        
        private System.Nullable<float> TotalPagoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TpPagamentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TpAcaoField;
        
        private System.Nullable<int> NroAcordoField;
        
        private System.Nullable<int> ParcAcordoField;
        
        private System.Nullable<int> ParTotalField;
        
        private System.Nullable<float> ValEntradaField;
        
        private System.Nullable<float> ValParcelaField;
        
        private System.Nullable<System.DateTime> VencProxParcelaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusField;
        
        private System.Nullable<int> IdProcessaField;
        
        private System.Nullable<int> TpFormaField;
        
        private System.Nullable<int> CdEmpresaField;
        
        private System.Nullable<int> CdDevField;
        
        private System.Nullable<int> SeqLancField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string PdVenda {
            get {
                return this.PdVendaField;
            }
            set {
                if ((object.ReferenceEquals(this.PdVendaField, value) != true)) {
                    this.PdVendaField = value;
                    this.RaisePropertyChanged("PdVenda");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Contrato {
            get {
                return this.ContratoField;
            }
            set {
                if ((object.ReferenceEquals(this.ContratoField, value) != true)) {
                    this.ContratoField = value;
                    this.RaisePropertyChanged("Contrato");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public System.Nullable<int> IdParcela {
            get {
                return this.IdParcelaField;
            }
            set {
                if ((this.IdParcelaField.Equals(value) != true)) {
                    this.IdParcelaField = value;
                    this.RaisePropertyChanged("IdParcela");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public System.Nullable<float> Valor {
            get {
                return this.ValorField;
            }
            set {
                if ((this.ValorField.Equals(value) != true)) {
                    this.ValorField = value;
                    this.RaisePropertyChanged("Valor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public System.Nullable<float> ValorJuros {
            get {
                return this.ValorJurosField;
            }
            set {
                if ((this.ValorJurosField.Equals(value) != true)) {
                    this.ValorJurosField = value;
                    this.RaisePropertyChanged("ValorJuros");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public System.Nullable<float> ValorDesconto {
            get {
                return this.ValorDescontoField;
            }
            set {
                if ((this.ValorDescontoField.Equals(value) != true)) {
                    this.ValorDescontoField = value;
                    this.RaisePropertyChanged("ValorDesconto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=6)]
        public System.Nullable<float> TotalPago {
            get {
                return this.TotalPagoField;
            }
            set {
                if ((this.TotalPagoField.Equals(value) != true)) {
                    this.TotalPagoField = value;
                    this.RaisePropertyChanged("TotalPago");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string TpPagamento {
            get {
                return this.TpPagamentoField;
            }
            set {
                if ((object.ReferenceEquals(this.TpPagamentoField, value) != true)) {
                    this.TpPagamentoField = value;
                    this.RaisePropertyChanged("TpPagamento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string TpAcao {
            get {
                return this.TpAcaoField;
            }
            set {
                if ((object.ReferenceEquals(this.TpAcaoField, value) != true)) {
                    this.TpAcaoField = value;
                    this.RaisePropertyChanged("TpAcao");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=9)]
        public System.Nullable<int> NroAcordo {
            get {
                return this.NroAcordoField;
            }
            set {
                if ((this.NroAcordoField.Equals(value) != true)) {
                    this.NroAcordoField = value;
                    this.RaisePropertyChanged("NroAcordo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=10)]
        public System.Nullable<int> ParcAcordo {
            get {
                return this.ParcAcordoField;
            }
            set {
                if ((this.ParcAcordoField.Equals(value) != true)) {
                    this.ParcAcordoField = value;
                    this.RaisePropertyChanged("ParcAcordo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=11)]
        public System.Nullable<int> ParTotal {
            get {
                return this.ParTotalField;
            }
            set {
                if ((this.ParTotalField.Equals(value) != true)) {
                    this.ParTotalField = value;
                    this.RaisePropertyChanged("ParTotal");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=12)]
        public System.Nullable<float> ValEntrada {
            get {
                return this.ValEntradaField;
            }
            set {
                if ((this.ValEntradaField.Equals(value) != true)) {
                    this.ValEntradaField = value;
                    this.RaisePropertyChanged("ValEntrada");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=13)]
        public System.Nullable<float> ValParcela {
            get {
                return this.ValParcelaField;
            }
            set {
                if ((this.ValParcelaField.Equals(value) != true)) {
                    this.ValParcelaField = value;
                    this.RaisePropertyChanged("ValParcela");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=14)]
        public System.Nullable<System.DateTime> VencProxParcela {
            get {
                return this.VencProxParcelaField;
            }
            set {
                if ((this.VencProxParcelaField.Equals(value) != true)) {
                    this.VencProxParcelaField = value;
                    this.RaisePropertyChanged("VencProxParcela");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=15)]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=16)]
        public System.Nullable<int> IdProcessa {
            get {
                return this.IdProcessaField;
            }
            set {
                if ((this.IdProcessaField.Equals(value) != true)) {
                    this.IdProcessaField = value;
                    this.RaisePropertyChanged("IdProcessa");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=17)]
        public System.Nullable<int> TpForma {
            get {
                return this.TpFormaField;
            }
            set {
                if ((this.TpFormaField.Equals(value) != true)) {
                    this.TpFormaField = value;
                    this.RaisePropertyChanged("TpForma");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=18)]
        public System.Nullable<int> CdEmpresa {
            get {
                return this.CdEmpresaField;
            }
            set {
                if ((this.CdEmpresaField.Equals(value) != true)) {
                    this.CdEmpresaField = value;
                    this.RaisePropertyChanged("CdEmpresa");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=19)]
        public System.Nullable<int> CdDev {
            get {
                return this.CdDevField;
            }
            set {
                if ((this.CdDevField.Equals(value) != true)) {
                    this.CdDevField = value;
                    this.RaisePropertyChanged("CdDev");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=20)]
        public System.Nullable<int> SeqLanc {
            get {
                return this.SeqLancField;
            }
            set {
                if ((this.SeqLancField.Equals(value) != true)) {
                    this.SeqLancField = value;
                    this.RaisePropertyChanged("SeqLanc");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CarSystemStatusDevedor", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class CarSystemStatusDevedor : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.Nullable<int> CodDevedorField;
        
        private System.Nullable<int> CodClienteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContratoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FormaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ObsField;
        
        private System.Nullable<System.DateTime> DtGeraField;
        
        private System.Nullable<double> ValTotalAcordoField;
        
        private System.Nullable<System.DateTime> VencAcordoField;
        
        private System.Nullable<System.DateTime> DtAcordoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.Nullable<int> CodDevedor {
            get {
                return this.CodDevedorField;
            }
            set {
                if ((this.CodDevedorField.Equals(value) != true)) {
                    this.CodDevedorField = value;
                    this.RaisePropertyChanged("CodDevedor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public System.Nullable<int> CodCliente {
            get {
                return this.CodClienteField;
            }
            set {
                if ((this.CodClienteField.Equals(value) != true)) {
                    this.CodClienteField = value;
                    this.RaisePropertyChanged("CodCliente");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Contrato {
            get {
                return this.ContratoField;
            }
            set {
                if ((object.ReferenceEquals(this.ContratoField, value) != true)) {
                    this.ContratoField = value;
                    this.RaisePropertyChanged("Contrato");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string Forma {
            get {
                return this.FormaField;
            }
            set {
                if ((object.ReferenceEquals(this.FormaField, value) != true)) {
                    this.FormaField = value;
                    this.RaisePropertyChanged("Forma");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string Obs {
            get {
                return this.ObsField;
            }
            set {
                if ((object.ReferenceEquals(this.ObsField, value) != true)) {
                    this.ObsField = value;
                    this.RaisePropertyChanged("Obs");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=6)]
        public System.Nullable<System.DateTime> DtGera {
            get {
                return this.DtGeraField;
            }
            set {
                if ((this.DtGeraField.Equals(value) != true)) {
                    this.DtGeraField = value;
                    this.RaisePropertyChanged("DtGera");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=7)]
        public System.Nullable<double> ValTotalAcordo {
            get {
                return this.ValTotalAcordoField;
            }
            set {
                if ((this.ValTotalAcordoField.Equals(value) != true)) {
                    this.ValTotalAcordoField = value;
                    this.RaisePropertyChanged("ValTotalAcordo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=8)]
        public System.Nullable<System.DateTime> VencAcordo {
            get {
                return this.VencAcordoField;
            }
            set {
                if ((this.VencAcordoField.Equals(value) != true)) {
                    this.VencAcordoField = value;
                    this.RaisePropertyChanged("VencAcordo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=9)]
        public System.Nullable<System.DateTime> DtAcordo {
            get {
                return this.DtAcordoField;
            }
            set {
                if ((this.DtAcordoField.Equals(value) != true)) {
                    this.DtAcordoField = value;
                    this.RaisePropertyChanged("DtAcordo");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="tmkService.TmkServicosSoap")]
    public interface TmkServicosSoap {
        
        // CODEGEN: Generating message contract since element name login from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SetReadCarSystemPC", ReplyAction="*")]
        SGB.tmkService.SetReadCarSystemPCResponse SetReadCarSystemPC(SGB.tmkService.SetReadCarSystemPCRequest request);
        
        // CODEGEN: Generating message contract since element name login from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetCarSystemPC", ReplyAction="*")]
        SGB.tmkService.GetCarSystemPCResponse GetCarSystemPC(SGB.tmkService.GetCarSystemPCRequest request);
        
        // CODEGEN: Generating message contract since element name login from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetCarSystem_StatusDevedor", ReplyAction="*")]
        SGB.tmkService.GetCarSystem_StatusDevedorResponse GetCarSystem_StatusDevedor(SGB.tmkService.GetCarSystem_StatusDevedorRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SetReadCarSystemPCRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SetReadCarSystemPC", Namespace="http://tempuri.org/", Order=0)]
        public SGB.tmkService.SetReadCarSystemPCRequestBody Body;
        
        public SetReadCarSystemPCRequest() {
        }
        
        public SetReadCarSystemPCRequest(SGB.tmkService.SetReadCarSystemPCRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class SetReadCarSystemPCRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string login;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string pwd;
        
        public SetReadCarSystemPCRequestBody() {
        }
        
        public SetReadCarSystemPCRequestBody(string login, string pwd) {
            this.login = login;
            this.pwd = pwd;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SetReadCarSystemPCResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SetReadCarSystemPCResponse", Namespace="http://tempuri.org/", Order=0)]
        public SGB.tmkService.SetReadCarSystemPCResponseBody Body;
        
        public SetReadCarSystemPCResponse() {
        }
        
        public SetReadCarSystemPCResponse(SGB.tmkService.SetReadCarSystemPCResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class SetReadCarSystemPCResponseBody {
        
        public SetReadCarSystemPCResponseBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetCarSystemPCRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetCarSystemPC", Namespace="http://tempuri.org/", Order=0)]
        public SGB.tmkService.GetCarSystemPCRequestBody Body;
        
        public GetCarSystemPCRequest() {
        }
        
        public GetCarSystemPCRequest(SGB.tmkService.GetCarSystemPCRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetCarSystemPCRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string login;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string pwd;
        
        public GetCarSystemPCRequestBody() {
        }
        
        public GetCarSystemPCRequestBody(string login, string pwd) {
            this.login = login;
            this.pwd = pwd;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetCarSystemPCResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetCarSystemPCResponse", Namespace="http://tempuri.org/", Order=0)]
        public SGB.tmkService.GetCarSystemPCResponseBody Body;
        
        public GetCarSystemPCResponse() {
        }
        
        public GetCarSystemPCResponse(SGB.tmkService.GetCarSystemPCResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetCarSystemPCResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public SGB.tmkService.CarSystemPC[] GetCarSystemPCResult;
        
        public GetCarSystemPCResponseBody() {
        }
        
        public GetCarSystemPCResponseBody(SGB.tmkService.CarSystemPC[] GetCarSystemPCResult) {
            this.GetCarSystemPCResult = GetCarSystemPCResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetCarSystem_StatusDevedorRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetCarSystem_StatusDevedor", Namespace="http://tempuri.org/", Order=0)]
        public SGB.tmkService.GetCarSystem_StatusDevedorRequestBody Body;
        
        public GetCarSystem_StatusDevedorRequest() {
        }
        
        public GetCarSystem_StatusDevedorRequest(SGB.tmkService.GetCarSystem_StatusDevedorRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetCarSystem_StatusDevedorRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string login;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string pwd;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int codCliente;
        
        public GetCarSystem_StatusDevedorRequestBody() {
        }
        
        public GetCarSystem_StatusDevedorRequestBody(string login, string pwd, int codCliente) {
            this.login = login;
            this.pwd = pwd;
            this.codCliente = codCliente;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetCarSystem_StatusDevedorResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetCarSystem_StatusDevedorResponse", Namespace="http://tempuri.org/", Order=0)]
        public SGB.tmkService.GetCarSystem_StatusDevedorResponseBody Body;
        
        public GetCarSystem_StatusDevedorResponse() {
        }
        
        public GetCarSystem_StatusDevedorResponse(SGB.tmkService.GetCarSystem_StatusDevedorResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetCarSystem_StatusDevedorResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public SGB.tmkService.CarSystemStatusDevedor[] GetCarSystem_StatusDevedorResult;
        
        public GetCarSystem_StatusDevedorResponseBody() {
        }
        
        public GetCarSystem_StatusDevedorResponseBody(SGB.tmkService.CarSystemStatusDevedor[] GetCarSystem_StatusDevedorResult) {
            this.GetCarSystem_StatusDevedorResult = GetCarSystem_StatusDevedorResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TmkServicosSoapChannel : SGB.tmkService.TmkServicosSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TmkServicosSoapClient : System.ServiceModel.ClientBase<SGB.tmkService.TmkServicosSoap>, SGB.tmkService.TmkServicosSoap {
        
        public TmkServicosSoapClient() {
        }
        
        public TmkServicosSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TmkServicosSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TmkServicosSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TmkServicosSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SGB.tmkService.SetReadCarSystemPCResponse SGB.tmkService.TmkServicosSoap.SetReadCarSystemPC(SGB.tmkService.SetReadCarSystemPCRequest request) {
            return base.Channel.SetReadCarSystemPC(request);
        }
        
        public void SetReadCarSystemPC(string login, string pwd) {
            SGB.tmkService.SetReadCarSystemPCRequest inValue = new SGB.tmkService.SetReadCarSystemPCRequest();
            inValue.Body = new SGB.tmkService.SetReadCarSystemPCRequestBody();
            inValue.Body.login = login;
            inValue.Body.pwd = pwd;
            SGB.tmkService.SetReadCarSystemPCResponse retVal = ((SGB.tmkService.TmkServicosSoap)(this)).SetReadCarSystemPC(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SGB.tmkService.GetCarSystemPCResponse SGB.tmkService.TmkServicosSoap.GetCarSystemPC(SGB.tmkService.GetCarSystemPCRequest request) {
            return base.Channel.GetCarSystemPC(request);
        }
        
        public SGB.tmkService.CarSystemPC[] GetCarSystemPC(string login, string pwd) {
            SGB.tmkService.GetCarSystemPCRequest inValue = new SGB.tmkService.GetCarSystemPCRequest();
            inValue.Body = new SGB.tmkService.GetCarSystemPCRequestBody();
            inValue.Body.login = login;
            inValue.Body.pwd = pwd;
            SGB.tmkService.GetCarSystemPCResponse retVal = ((SGB.tmkService.TmkServicosSoap)(this)).GetCarSystemPC(inValue);
            return retVal.Body.GetCarSystemPCResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SGB.tmkService.GetCarSystem_StatusDevedorResponse SGB.tmkService.TmkServicosSoap.GetCarSystem_StatusDevedor(SGB.tmkService.GetCarSystem_StatusDevedorRequest request) {
            return base.Channel.GetCarSystem_StatusDevedor(request);
        }
        
        public SGB.tmkService.CarSystemStatusDevedor[] GetCarSystem_StatusDevedor(string login, string pwd, int codCliente) {
            SGB.tmkService.GetCarSystem_StatusDevedorRequest inValue = new SGB.tmkService.GetCarSystem_StatusDevedorRequest();
            inValue.Body = new SGB.tmkService.GetCarSystem_StatusDevedorRequestBody();
            inValue.Body.login = login;
            inValue.Body.pwd = pwd;
            inValue.Body.codCliente = codCliente;
            SGB.tmkService.GetCarSystem_StatusDevedorResponse retVal = ((SGB.tmkService.TmkServicosSoap)(this)).GetCarSystem_StatusDevedor(inValue);
            return retVal.Body.GetCarSystem_StatusDevedorResult;
        }
    }
}

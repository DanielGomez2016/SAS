<template>
  <div>
    <input v-model="Id" type="hidden" name="Id">
    <div class="alert-container"></div>
    <div class="form-group">
      <div class="form-group">
        <label>Nombre</label>
        <input v-model="Name" type="text" class="form-control" name="Name">
        <span data-key="Name" class="form-validation-failed"></span>
      </div>
      
      <div class="form-group">
        <label>Siglas</label>
        <input v-model="Acronym" type="text" class="form-control" name="Acronym">
        <span data-key="Acronym" class="form-validation-failed"></span>
      </div>
      
      <div class="form-group">
        <label>Titular</label>
        <input v-model="Manager" type="text" class="form-control" name="Manager">
      </div>
      <span data-key="Manager" class="form-validation-failed"></span>
      <div class="form-group">
        <label>Descripcion</label>
        <input v-model="Description" type="text" class="form-control" name="Description">
        <span data-key="Description" class="form-validation-failed"></span>
      </div>
      
      <div class="form-group">
        <label>Telefono</label>
        <input v-model="Phone" type="text" class="form-control" name="Phone">
        <span data-key="Phone" class="form-validation-failed"></span>
      </div>
      
      <div class="form-group">
        <label>Extencion</label>
        <input v-model="extension" type="text" class="form-control" name="extension">
         <span data-key="extension" class="form-validation-failed"></span>
      </div>
     
    </div>
  </div>
</template>

<script>
import icon from './global.icon.vue'
export default {
  components:{
    icon
  },
  data(){
    return{
    Id: 0,
    Name: '',
    Acronym: '',
    Manager: '',
    Description: '',
    Phone: '',
    extension: '',
    
    }
  },
  name: 'institute',
  props: {
    url: {
      type: String,
      required: true
    }
  },
  mounted() {
    var self = this;
    this.$parent.$on('instituteSelectedId', function(v){
      self.Id = parseInt(v);
    })
  },
  watch:{
    Id(newValue, oldValue){
      if(newValue > 0){
        this.getInstitute(newValue);
      }else{
        this.newRecord();
      }
    }
  },
  methods:{
    getInstitute(id){
      var self = this;
      $.post(self.url, { id: id }, function(r){
        self.Name = r.Name;
        self.Acronym = r.Acronym;
        self.Manager = r.Manager;
        self.Description = r.Description;
        self.Phone = r.Phone;
        self.extension = r.extension;
        self.Id = id;
      },'json')
    }, 
    newRecord(){
      var self = this;
        self.Name = '';
        self.Acronym = '';
        self.Manager = '';
        self.Description = '';
        self.Phone = '';
        self.extension = '';
        self.Id = 0;
    }
  }
}
</script>
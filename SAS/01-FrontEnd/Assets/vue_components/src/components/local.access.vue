<template>
  <div>
    <input v-model="Id" type="hidden" name="Id">
    <div class="alert-container"></div>
    <div class="form-group">
      <div class="form-group">
        <label>Controlador</label>
        <input v-model="Controller" type="text" class="form-control" name="Controller">
        <span data-key="Controller" class="form-validation-failed"></span>
      </div>
      
      <div class="form-group">
        <label>Accion</label>
        <input v-model="ActionController" type="text" class="form-control" name="ActionController">  
        <span data-key="ActionController" class="form-validation-failed"></span>
      </div>
      
      <div class="form-group">
        <label>Descripcion</label>
        <input v-model="DescriptionAccess" type="text" class="form-control" name="DescriptionAccess">
        <span data-key="DescriptionAccess" class="form-validation-failed"></span>
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
    Controller: '',
    ActionController: '',
    DescriptionAccess: '',
    }
  },
  name: 'access',
  props: {
    url: {
      type: String,
      required: true
    }
  },
  mounted() {
    var self = this;
    this.$parent.$on('accessSelectedId', function(v){
      self.Id = parseInt(v);
    })
  },
  watch:{
    Id(newValue, oldValue){
      if(newValue > 0){
        this.getAccess(newValue);
      }else{
        this.newRecord();
      }
    }
  },
  methods:{
    getAccess(id){
      var self = this;
      $.post(self.url, { id: id }, function(r){
        self.Controller = r.Controller;
        self.ActionController = r.ActionController;
        self.DescriptionAccess = r.DescriptionAccess;
        self.Id = id;
      },'json')
    }, 
    newRecord(){
      var self = this;
      self.Controller = '';
      self.ActionController = '';
      self.DescriptionAccess = '';
      self.Id = 0;
    }
  }
}
</script>
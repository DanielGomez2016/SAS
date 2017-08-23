<template>
  <div>
    <input v-model="Id" type="hidden" name="Id">
    <div class="alert-container"></div>
    <div class="form-group">
        <label>Email</label>
        <input v-model="Email" type="email" class="form-control" name="Email">
        <span data-key="Email" class="form-validation-failed"></span>
      </div>
      
      <div class="form-group">
        <label>Nombre</label>
        <input v-model="Name" type="text" class="form-control" name="Name">
        <span data-key="Name" class="form-validation-failed"></span>
      </div>
      
      <div class="form-group">
        <label>Apellidos</label>
        <input v-model="LastName" type="text" class="form-control" name="LastName">
        <span data-key="LastName" class="form-validation-failed"></span>
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
    Email: '',
    Name: '',
    LastName: '',   
    }
  },
  name: 'usersedit',
  props: {
    url: {
      type: String,
      required: true
    }
  },
  mounted() {
    var self = this;
    this.$parent.$on('userSelectedId', function(v){
      self.Id = v;
    })
  },
  watch:{
    Id(newValue, oldValue){
      if(newValue != null){
        this.getUser(newValue);
      }
    }
  },
  methods:{
    getUser(id){
      var self = this;
      $.post(self.url, { id: id }, function(r){
        self.Email = r.Email;
        self.Name = r.Name;
        self.LastName = r.LastName;
        self.Id = id;
      },'json')
    }, 
  }
}
</script>
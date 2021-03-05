<template>
	<v-col cols="4">
		<v-card
		class="mx-auto"
		height="100%"
	>
		<v-card-text>
		<p class="display-1 text--primary">
			{{ book.title }}
		</p>
		<p>{{ book.author }}</p>
		</v-card-text>
		<v-card-actions bottom>
			<v-btn
				text
				color="red accent-4"
				@click="reveal = true"
			>
				Delete
			</v-btn>
		</v-card-actions>
	</v-card>
	</v-col>
</template>

<script lang="ts">

  import IBook from '@/types/Book';
import { Component, Prop, Vue } from 'vue-property-decorator';

  @Component({
    name: 'Book',
    components: {}
  })

  export default class Book extends Vue {
	@Prop({ required: true })
	book!: IBook;

  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
	.v-card__text {
		padding-bottom: 50px;
	}
	
	.v-card__actions {
		position: absolute;
		bottom: 0;
	}
</style>

<template>
  <v-card class="mx-auto mb-6" >

	<v-card-text>
		<v-rating
		:value="review.reviewRating"
		color="amber"
		dense
		half-increments
		readonly
		size="14"
		class="mb-2 "
		></v-rating>
		<div class="mb-1 subtitle-1">
			{{ review.reviewAuthor }}
		</div>

		<div>{{ review.reviewContent }}</div>
	</v-card-text>

	
	<v-btn
		color="red lighten-2"
		text
		class="delete"
		@click="deleteReview(review.id)"
	>
		<v-icon color="red lighten-1">mdi-delete</v-icon>
	</v-btn>
</v-card>
</template>

<script lang="ts">
  import ReviewService from "@/services/review-service";
  import IReview from '@/types/Review';
  import { Component, Prop, Vue } from 'vue-property-decorator';

  const reviewService = new ReviewService();

  @Component({
    name: 'Review',
    components: {}
  })

  export default class Review extends Vue {
    active = false;

    @Prop({ required: true })
    review!: IReview;

    async deleteReview(reviewId: number){

      await reviewService.deleteBookReview(reviewId)
        .then(() => {
          //console.log(res);
          this.$emit('reloadReviews');
        })
        .catch(err => console.error(err));

    }

  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
    .delete {
        position: absolute;
        top: 10px;
        right: 10px;
    }
</style>

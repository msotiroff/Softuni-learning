<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Product;
use AppBundle\Form\ProductType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class ProductController extends Controller
{
    /**
     * @param Request $request
     * @Route("/", name="index")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function index(Request $request)
    {
        $allProducts = $this
            ->getDoctrine()
            ->getRepository('AppBundle:Product')
            ->findAll();

        return $this->render('product/index.html.twig', ['products' => $allProducts]);
	}

    /**
     * @param Request $request
     * @Route("/create", name="create")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function create(Request $request)
    {
        $productToCreate = new Product();

        $form = $this->createForm(ProductType::class, $productToCreate);

        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()) {

            if ($productToCreate->getName() == null
                || $productToCreate->getPriority() == null
                || $productToCreate->getStatus() == null
                || $productToCreate->getQuantity() == null
                || $productToCreate->getQuantity() <= 0) {
                return $this->redirectToRoute('index');
            }

            if ($productToCreate->getName() != ""
                && $productToCreate->getPriority() != ""
                && $productToCreate->getQuantity() != ""
                && $productToCreate->getStatus() != "") {

                $em = $this->getDoctrine()->getManager();
                $em->persist($productToCreate);
                $em->flush();
            }

            return $this->redirectToRoute('index');
        }

        return $this->render('product/create.html.twig', ['form' => $form->createView()]);
	}

    /**
     * @Route("/edit/{id}", name="edit")
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function edit($id, Request $request)
    {
        $productToEdit = $this->getDoctrine()->getRepository(Product::class)->find($id);

        if ($productToEdit == null) {
            return $this->redirectToRoute('index');
        }

        $form = $this->createForm(ProductType::class, $productToEdit);

        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()) {

            if ($productToEdit->getName() == null
                || $productToEdit->getPriority() == null
                || $productToEdit->getStatus() == null
                || $productToEdit->getQuantity() == null
                || $productToEdit->getQuantity() <= 0) {
                return $this->redirectToRoute('index');
            }

            if ($productToEdit->getName() != ""
                && $productToEdit->getPriority() != ""
                && $productToEdit->getQuantity() != ""
                && $productToEdit->getStatus() != "") {

                $em = $this->getDoctrine()->getManager();
                $em->persist($productToEdit);
                $em->flush();
            }


            return $this->redirectToRoute('index');
        }

        return $this->render('product/edit.html.twig', ['product' => $productToEdit, 'form' => $form->createView()]);
    }
}
